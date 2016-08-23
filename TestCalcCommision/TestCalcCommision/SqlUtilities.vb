Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Reflection
Imports Dapper

Public Class SqlUtilities

    Private Shared connection As New SqlConnection(ConfigurationManager.ConnectionStrings("SqlServerConnString").ConnectionString)

    Private Shared dbTypeList As New List(Of KeyValuePair(Of String, SqlDbType))() From { _
        New KeyValuePair(Of String, SqlDbType)("int", SqlDbType.Int), _
        New KeyValuePair(Of String, SqlDbType)("varchar", SqlDbType.VarChar), _
        New KeyValuePair(Of String, SqlDbType)("bit", SqlDbType.Bit), _
        New KeyValuePair(Of String, SqlDbType)("datetime", SqlDbType.DateTime), _
        New KeyValuePair(Of String, SqlDbType)("decimal", SqlDbType.[Decimal]), _
        New KeyValuePair(Of String, SqlDbType)("image", SqlDbType.Image) _
    }

    Private Shared SqlTypeDapperList As New List(Of KeyValuePair(Of SqlDbType, DbType))() From { _
       New KeyValuePair(Of SqlDbType, DbType)(SqlDbType.Int, DbType.Int32), _
       New KeyValuePair(Of SqlDbType, DbType)(SqlDbType.VarChar, DbType.String), _
       New KeyValuePair(Of SqlDbType, DbType)(SqlDbType.Bit, DbType.Boolean), _
       New KeyValuePair(Of SqlDbType, DbType)(SqlDbType.DateTime, DbType.DateTime), _
       New KeyValuePair(Of SqlDbType, DbType)(SqlDbType.[Decimal], DbType.[Decimal]), _
       New KeyValuePair(Of SqlDbType, DbType)(SqlDbType.Date, DbType.Date) _
   }
    Private Shared Function FindInSqlDbTypeList(NativeDbType As String) As SqlDbType
        For Each _DbListItem As KeyValuePair(Of String, SqlDbType) In dbTypeList
            If _DbListItem.Key = NativeDbType Then
                Return _DbListItem.Value
            End If
        Next

        Return SqlDbType.[Variant]

    End Function

    Private Shared Function FindInDbTypeList(SqlDbType As SqlDbType) As DbType
        For Each _DbListItem As KeyValuePair(Of SqlDbType, DbType) In SqlTypeDapperList
            If _DbListItem.Key = SqlDbType Then
                Return _DbListItem.Value
            End If
        Next

        Return SqlDbType.Variant

    End Function

    Private Shared Function GetColumsAndTypes(Table As String) As DataSet
        Dim _DataSet As New DataSet

        Dim _Command As New SqlCommand((Convert.ToString("SELECT syscolumns.name, syscolumns.length, systypes.name FROM syscolumns " + "INNER JOIN systypes ON syscolumns.xtype = systypes.xtype " + "WHERE syscolumns.id = object_id('") & Table) + "') AND systypes.name<>'sysname'", connection)

        Dim _Adapter As New SqlDataAdapter(_Command)

        _Adapter.Fill(_DataSet, Table)

        Return _DataSet
    End Function

    Private Shared Function GetParameters(Table As String) As SqlParameter()
        Dim _Parameters As SqlParameter() = New SqlParameter(-1) {}
        Dim _DataSet As DataSet = GetColumsAndTypes(Table)

        For Each _Row As DataRow In _DataSet.Tables(0).Rows
            Array.Resize(_Parameters, _Parameters.Length + 1)
            _Parameters(_Parameters.Length - 1) = New SqlParameter("@" + _Row(0).ToString(), FindInDbTypeList(_Row(2).ToString()), Convert.ToInt32(_Row(1)), _Row(0).ToString())
        Next

        Return _Parameters
    End Function

#Region "Parameter"
    Public Shared Function CreateParameter(ByVal parameterName As String, ByVal type As SqlDbType, ByRef value As Object) As SqlParameter
        Dim param As New SqlParameter(parameterName, type)
        param.Value = value
        param.Direction = ParameterDirection.Input
        Return param
    End Function

    Public Shared Function CreateParameter(ByVal parameterName As String, ByVal type As SqlDbType, ByRef value As Object, ByVal direction As ParameterDirection) As SqlParameter
        Dim param As New SqlParameter(parameterName, type)
        param.Value = value
        param.Direction = direction
        Return param
    End Function

    Public Shared Function CreateParameter(ByVal parameterName As String, ByVal type As SqlDbType, ByVal size As Integer, ByRef value As Object, ByVal direction As ParameterDirection) As SqlParameter
        Dim param As New SqlParameter(parameterName, type, size)
        param.Value = value
        param.Direction = direction
        Return param
    End Function
    Public Shared Function GetParameters(Table As String, ByVal obj As Object) As Dictionary(Of String, SqlParameter)
        Dim _DictParameters As Dictionary(Of String, SqlParameter) = New Dictionary(Of String, SqlParameter)
        Dim _DataSet As DataSet = GetColumsAndTypes(Table)
        Dim lstPi As List(Of PropertyInfo) = obj.GetType().GetProperties().ToList()
        Dim _typeObj As Type = obj.GetType()


        For Each _Row As DataRow In _DataSet.Tables(0).Rows
            If _typeObj.GetProperties().ToList().Any(Function(o) o.Name = _Row(0).ToString()) Then
                _DictParameters.Add(_Row(0).ToString(), CreateParameter("@" + _Row(0).ToString(), FindInSqlDbTypeList(_Row(2).ToString()) _
                                                                      , IIf(_typeObj.GetProperty(_Row(0).ToString()).GetValue(obj, Nothing) Is Nothing, DBNull.Value, _
                                                                          _typeObj.GetProperty(_Row(0).ToString()).GetValue(obj, Nothing)) _
                                                                      , ParameterDirection.Input
                                                                 ) _
                             )
            End If
         

        Next

        Return _DictParameters
    End Function

    Public Shared Function GetDynamicParameters(ByVal dictsqlParam As Dictionary(Of String, SqlParameter)) As DynamicParameters
        Dim parameters = New DynamicParameters()


        For i As Integer = 0 To dictsqlParam.Count - 1
            Dim sqlParam = dictsqlParam(dictsqlParam.Keys(i))
            parameters.Add(sqlParam.ParameterName, sqlParam.Value, dbType:=FindInDbTypeList(sqlParam.SqlDbType), direction:=sqlParam.Direction)
        Next

        Return parameters
    End Function

   
#End Region

    

  

    Private Shared Function CreateInsertCommand(Table As String, CommandString As String, IdentityColumn As String, IsStoredProcedure As Boolean) As SqlCommand
        Dim _Command As New SqlCommand(CommandString, connection)
        If IsStoredProcedure Then
            _Command.CommandType = CommandType.StoredProcedure
        End If
        _Command.Parameters.AddRange(GetParameters(Table))
        _Command.Parameters(Convert.ToString("@") & IdentityColumn).Direction = ParameterDirection.Output

        Return _Command
    End Function

    Private Shared Function CreateUpdateCommand(Table As String, CommandString As String, IsStoredProcedure As Boolean) As SqlCommand
        Dim _Command As New SqlCommand(CommandString, connection)
        If IsStoredProcedure Then
            _Command.CommandType = CommandType.StoredProcedure
        End If
        _Command.Parameters.AddRange(GetParameters(Table))

        Return _Command
    End Function

    Private Shared Function CreateDeleteCommand(Table As String, IdentityColumn As String) As SqlCommand
        Dim _Command As New SqlCommand(Convert.ToString((Convert.ToString((Convert.ToString("DELETE FROM ") & Table) + " WHERE ") & IdentityColumn) + " = @") & IdentityColumn, connection)
        _Command.Parameters.Add(New SqlParameter(Convert.ToString("@") & IdentityColumn, SqlDbType.Int, 4, IdentityColumn))

        Return _Command
    End Function

    Public Shared Sub CreateAdapterCommands(ByRef Adapter As SqlDataAdapter, Table As String, InsertCommandString As String, IsInsertStoredProcedure As Boolean, UpdateCommandString As String, IsUpdateStoredProcedure As Boolean, _
        IdentityColumn As String)
        Adapter.InsertCommand = CreateInsertCommand(Table, InsertCommandString, IdentityColumn, IsInsertStoredProcedure)
        Adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.OutputParameters
        Adapter.UpdateCommand = CreateUpdateCommand(Table, UpdateCommandString, IsUpdateStoredProcedure)
        Adapter.DeleteCommand = CreateDeleteCommand(Table, IdentityColumn)
    End Sub


End Class
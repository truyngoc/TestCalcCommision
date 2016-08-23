Public Class frmCommision



    Public Sub CreateTree(ByVal o As MSA_MemberInfo, ByVal nodeLevel As Integer, ByRef _lstMem As List(Of MSA_MemberInfo))    
        Dim oLeft = New MSA_MemberInfo
        oLeft.MA_KH = o.MA_CAY + "01"
        oLeft.MAT_KHAU = "123456"
        oLeft.MA_CAY = o.MA_CAY + "01"
        oLeft.MA_BAO_TRO = "0"
        oLeft.TEN = "cusL"
        oLeft.MA_BAO_TRO_TT = ""
        oLeft.MA_CAY_TT = o.MA_CAY
        oLeft.NHANH_CAY_TT = 1
        oLeft.NGAY_THAM_GIA = DateTime.Today
        oLeft.TRANG_THAI = 1
        oLeft.MA_GOI_DAU_TU = Convert.ToInt32(txtGoiDauTu.Text)

        _lstMem.Add(oLeft)

        ' Right            
        Dim oRight = New MSA_MemberInfo
        oRight.MA_KH = o.MA_CAY + "02"
        oRight.MAT_KHAU = "123456"
        oRight.MA_CAY = o.MA_CAY + "02"
        oRight.MA_BAO_TRO = "0"
        oRight.TEN = "cusR"
        oRight.MA_BAO_TRO_TT = ""
        oRight.MA_CAY_TT = o.MA_CAY
        oRight.NHANH_CAY_TT = 2
        oRight.NGAY_THAM_GIA = DateTime.Today
        oRight.TRANG_THAI = 1
        oRight.MA_GOI_DAU_TU = Convert.ToInt32(txtGoiDauTu.Text)

        _lstMem.Add(oRight)



        If nodeLevel > 0 Then
            CreateTree(oLeft, nodeLevel - 1, _lstMem)
            CreateTree(oRight, nodeLevel - 1, _lstMem)
        End If


    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
       
        ' progress bar
        progressBar1.Maximum = 100
        progressBar1.Step = 1
        progressBar1.Value = 0

        backgroundWorker1.RunWorkerAsync()
    End Sub




    Public Sub Chot_Doanh_So(ByVal thang As Integer, ByVal nam As Integer)
        Try
            Dim daoDS As New MSA_DOANH_SO_DAO
            Dim daoMem As New MSA_MemberDAO

            Dim lstMem As List(Of MSA_MemberInfo)
            Dim lstDS As New List(Of HOA_HONG)

            ' lay tat ca thanh vien
            lstMem = daoMem.get_All()

            ' tinh doanh so - hoa hong        
            For Each o As MSA_MemberInfo In lstMem
                Dim ds As HOA_HONG
                ds = daoDS.Tinh_Hoa_Hong(o.MA_CAY, o.MA_KH, thang, nam)

                ds.MA_KH = o.MA_KH
                ds.MA_DAU_TU = o.MA_GOI_DAU_TU
                ds.NAM = nam
                ds.THANG = thang

                lstDS.Add(ds)
            Next

            ' cap nhat vao db
            For Each d As HOA_HONG In lstDS
                daoDS.Insert(d)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub




    Private Sub backgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        Try
            Dim _lstMem = New List(Of MSA_MemberInfo)
            Dim daoMem As New MSA_MemberDAO

            ' PROGRESS
            backgroundWorker1.ReportProgress(0)

            ' reset
            daoMem.Reset_Member_HoaHong()


            ' PROGRESS
            backgroundWorker1.ReportProgress(5)


            Dim root = New MSA_MemberInfo
            root.MA_KH = "admin"
            root.MAT_KHAU = "1"
            root.MA_CAY = "0"
            root.MA_BAO_TRO = "0"
            root.TEN = "LiFE BETTER"
            root.NGAY_THAM_GIA = DateTime.Today
            root.TRANG_THAI = 1
            root.MA_GOI_DAU_TU = Convert.ToInt32(txtGoiDauTu.Text)

            _lstMem.Add(root)

            ' tao cay
            CreateTree(root, Convert.ToInt32(txtNumLevel.Text), _lstMem)

            ' PROGRESS
            backgroundWorker1.ReportProgress(10)

            ' insert vao db
            For Each m As MSA_MemberInfo In _lstMem
                daoMem.Insert_Demo(m)
            Next


            ' PROGRESS
            backgroundWorker1.ReportProgress(50)


            ' chot doanh so
            Chot_Doanh_So(DateTime.Today.Month, DateTime.Today.Year)


            ' PROGRESS
            backgroundWorker1.ReportProgress(100)
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub backgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        MessageBox.Show("Xong rồi!")
    End Sub

    Private Sub backgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles backgroundWorker1.ProgressChanged
        progressBar1.Value = e.ProgressPercentage
    End Sub
End Class
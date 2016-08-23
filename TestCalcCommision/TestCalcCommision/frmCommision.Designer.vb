<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommision
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtNumLevel = New System.Windows.Forms.TextBox()
        Me.btnCalc = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGoiDauTu = New System.Windows.Forms.TextBox()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'txtNumLevel
        '
        Me.txtNumLevel.Location = New System.Drawing.Point(179, 21)
        Me.txtNumLevel.Name = "txtNumLevel"
        Me.txtNumLevel.Size = New System.Drawing.Size(100, 20)
        Me.txtNumLevel.TabIndex = 0
        '
        'btnCalc
        '
        Me.btnCalc.Location = New System.Drawing.Point(179, 105)
        Me.btnCalc.Name = "btnCalc"
        Me.btnCalc.Size = New System.Drawing.Size(100, 50)
        Me.btnCalc.TabIndex = 2
        Me.btnCalc.Text = "Run"
        Me.btnCalc.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Số tầng của cây"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Gói đầu tư"
        '
        'txtGoiDauTu
        '
        Me.txtGoiDauTu.Location = New System.Drawing.Point(179, 61)
        Me.txtGoiDauTu.Name = "txtGoiDauTu"
        Me.txtGoiDauTu.Size = New System.Drawing.Size(100, 20)
        Me.txtGoiDauTu.TabIndex = 4
        '
        'progressBar1
        '
        Me.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.progressBar1.Location = New System.Drawing.Point(0, 185)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(405, 23)
        Me.progressBar1.TabIndex = 6
        '
        'backgroundWorker1
        '
        Me.backgroundWorker1.WorkerReportsProgress = True
        '
        'frmCommision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 208)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGoiDauTu)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCalc)
        Me.Controls.Add(Me.txtNumLevel)
        Me.Name = "frmCommision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tinh toan hh"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNumLevel As System.Windows.Forms.TextBox
    Friend WithEvents btnCalc As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGoiDauTu As System.Windows.Forms.TextBox
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class

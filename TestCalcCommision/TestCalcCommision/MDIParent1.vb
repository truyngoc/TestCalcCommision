Imports System.Windows.Forms

Public Class MDIParent1
    Private Sub mnuItemDemoCommision_Click(sender As Object, e As EventArgs) Handles mnuItemDemoCommision.Click
        frmCommision.MdiParent = Me
        frmCommision.Show()
    End Sub

    Private Sub mnuItemXemThongKe_Click(sender As Object, e As EventArgs) Handles mnuItemXemThongKe.Click
        ThongKe.MdiParent = Me
        ThongKe.Show()
    End Sub

    Private Sub mnuItemThongKeHeThong_Click(sender As Object, e As EventArgs) Handles mnuItemThongKeHeThong.Click
        ThongKeTong.MdiParent = Me
        ThongKeTong.Show()
    End Sub
End Class

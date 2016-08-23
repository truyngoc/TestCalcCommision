Public Class ThongKeTong

    Private Sub ThongKeTong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim daoHH As New MSA_DOANH_SO_DAO
        Dim oTK As THONG_KE_HE_THONG

        oTK = daoHH.ThongKeHeThong()

        txtTongSoThanhVien.Text = IIf(oTK.TONG_SO_THANH_VIEN = 0, 0, oTK.TONG_SO_THANH_VIEN.ToString("#,###"))
        txtTongDoanhSo.Text = IIf(oTK.TONG_DOANH_SO = 0, 0, oTK.TONG_DOANH_SO.ToString("#,###"))
        txtHHTT.Text = IIf(oTK.TONG_HOA_HONG_TRUC_TIEP = 0, 0, oTK.TONG_HOA_HONG_TRUC_TIEP.ToString("#,###"))
        txtHHGT.Text = IIf(oTK.TONG_HOA_HONG_GIAN_TIEP = 0, 0, oTK.TONG_HOA_HONG_GIAN_TIEP.ToString("#,###"))
        txtHHCBDT.Text = IIf(oTK.TONG_HOA_HONG_CO_BAN_DUOC_TINH = 0, 0, oTK.TONG_HOA_HONG_CO_BAN_DUOC_TINH.ToString("#,###"))
        txtQuyTienMat.Text = IIf(oTK.TONG_QUY_TIEN_MAT = 0, 0, oTK.TONG_QUY_TIEN_MAT.ToString("#,###"))
        txtQuyPCS.Text = IIf(oTK.TONG_QUY_PHONG_CACH = 0, 0, oTK.TONG_QUY_PHONG_CACH.ToString("#,###"))
        txtQuyDaoTao.Text = IIf(oTK.TONG_QUY_DAO_TAO = 0, 0, oTK.TONG_QUY_DAO_TAO.ToString("#,###"))
        txtTongCong.Text = IIf(oTK.TONG_HOA_HONG = 0, 0, oTK.TONG_HOA_HONG.ToString("#,###"))

    End Sub
End Class
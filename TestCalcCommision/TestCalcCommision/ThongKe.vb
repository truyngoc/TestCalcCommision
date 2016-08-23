Public Class ThongKe

    Private Sub ThongKe_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ThongKe()

    End Sub


    Public Sub Load_Data_To_Form_HOA_HONG(ByVal o As HOA_HONG)
        If o IsNot Nothing Then
            'lblTONG_THU_NHAP_CAC_KY.Text = IIf(o.TONG_THU_NHAP_CAC_KY = 0, 0, o.TONG_THU_NHAP_CAC_KY.ToString("#,###"))
            txtHHTT.Text = IIf(o.HOA_HONG_TRUC_TIEP = 0, 0, o.HOA_HONG_TRUC_TIEP.ToString("#,###"))
            txtHHGT.Text = IIf(o.HOA_HONG_GIAN_TIEP = 0, 0, o.HOA_HONG_GIAN_TIEP.ToString("#,###"))
            txtHHCB.Text = IIf(o.HOA_HONG_CO_BAN = 0, 0, o.HOA_HONG_CO_BAN.ToString("#,###"))
            txtHHCBDT.Text = IIf(o.HOA_HONG_CO_BAN_DUOC_TINH = 0, 0, o.HOA_HONG_CO_BAN_DUOC_TINH.ToString("#,###"))
            txtQuyTienMat.Text = IIf(o.QUY_TIEN_MAT = 0, 0, o.QUY_TIEN_MAT.ToString("#,###"))
            txtQuyPCS.Text = IIf(o.QUY_PHONG_CACH = 0, 0, o.QUY_PHONG_CACH.ToString("#,###"))
            txtQuyDaoTao.Text = IIf(o.QUY_DAO_TAO = 0, 0, o.QUY_DAO_TAO.ToString("#,###"))

            o.TONG_THU_NHAP_THANG = o.HOA_HONG_CO_BAN_DUOC_TINH + o.HOA_HONG_TRUC_TIEP + o.HOA_HONG_GIAN_TIEP
            txtTongCong.Text = IIf(o.TONG_THU_NHAP_THANG = 0, 0, o.TONG_THU_NHAP_THANG.ToString("#,###"))
        End If
    End Sub

    Public Sub Load_DaTa_To_Form_DOANH_SO(ByVal o As HOA_HONG)
        If o IsNot Nothing Then
            o.DOANH_SO_CA_NHAN = o.DOANH_SO_TRAI + o.DOANH_SO_PHAI
            o.DOANH_SO_TICH_LUY = o.DOANH_SO_TICH_LUY_TRAI + o.DOANH_SO_TICH_LUY_PHAI

            txtDSCaNhan.Text = IIf(o.DOANH_SO_CA_NHAN = 0, 0, o.DOANH_SO_CA_NHAN.ToString("#,###"))
            txtDSTichLuyThang.Text = IIf(o.DOANH_SO_TICH_LUY = 0, 0, o.DOANH_SO_TICH_LUY.ToString("#,###"))
            txtDSPhatSinhT.Text = IIf(o.DOANH_SO_TRAI = 0, 0, o.DOANH_SO_TRAI.ToString("#,###"))
            txtDSPhatSinhP.Text = IIf(o.DOANH_SO_PHAI = 0, 0, o.DOANH_SO_PHAI.ToString("#,###"))
            txtDSKetChuyenT.Text = IIf(o.DOANH_SO_KET_CHUYEN_TRAI = 0, 0, o.DOANH_SO_KET_CHUYEN_TRAI.ToString("#,###"))
            txtDSKetChuyenP.Text = IIf(o.DOANH_SO_KET_CHUYEN_PHAI = 0, 0, o.DOANH_SO_KET_CHUYEN_PHAI.ToString("#,###"))
            txtDSTichLuyT.Text = IIf(o.DOANH_SO_TICH_LUY_TRAI = 0, 0, o.DOANH_SO_TICH_LUY_TRAI.ToString("#,###"))
            txtDSTichLuyP.Text = IIf(o.DOANH_SO_TICH_LUY_PHAI = 0, 0, o.DOANH_SO_TICH_LUY_PHAI.ToString("#,###"))
            txtSoTVMT.Text = IIf(o.SO_THANH_VIEN_MOI_TRAI = 0, 0, o.SO_THANH_VIEN_MOI_TRAI.ToString("#,###"))
            txtSoTVMP.Text = IIf(o.SO_THANH_VIEN_MOI_PHAI = 0, 0, o.SO_THANH_VIEN_MOI_PHAI.ToString("#,###"))
            txtSoTVMBTT.Text = IIf(o.SO_THANH_VIEN_MOI_BAO_TRO_TRAI = 0, 0, o.SO_THANH_VIEN_MOI_BAO_TRO_TRAI.ToString("#,###"))
            txtSoTVMBTP.Text = IIf(o.SO_THANH_VIEN_MOI_BAO_TRO_PHAI = 0, 0, o.SO_THANH_VIEN_MOI_BAO_TRO_PHAI.ToString("#,###"))
        End If
    End Sub

    Private Sub btnThongKe_Click(sender As Object, e As EventArgs) Handles btnThongKe.Click
        ThongKe()
    End Sub


    Public Sub ThongKe()
        Dim dao = New MSA_DOANH_SO_DAO

        Dim lstHH As List(Of HOA_HONG)
        Try
            lstHH = dao.get_by_MA_KH(txtMA_KH.Text)


            Load_DaTa_To_Form_DOANH_SO(lstHH.FirstOrDefault)
            Load_Data_To_Form_HOA_HONG(lstHH.FirstOrDefault)

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
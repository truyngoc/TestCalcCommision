Public Class MSA_MemberInfo
    Public Property ID As Integer?
    Public Property MA_KH As String
    Public Property MAT_KHAU As String
    Public Property MA_CAY As String
    Public Property MA_BAO_TRO As String

    Public Property TEN As String
    Public Property CMND As String
    Public Property NGAY_SINH As Date?
    Public Property DIEN_THOAI As String
    Public Property DIA_CHI As String
    Public Property SO_TAI_KHOAN As String
    Public Property NGAN_HANG As String
    Public Property MST As String
    Public Property MA_BAO_TRO_TT As String
    Public Property TEN_BAO_TRO_TT As String
    Public Property MA_CAY_TT As String

    Public Property TEN_CAY_TT As String
    Public Property NHANH_CAY_TT As Integer '1 bên trái 2 bên phải
    Public Property NGAY_THAM_GIA As Date?
    Public Property TRANG_THAI As Integer? '0: chưa kích hoạt; 1: đã kích hoạt; 2: bị khóa
    Public Property MA_GOI_DAU_TU As Integer?
    Public Property TEN_GOI_DAU_TU As String
    Public Property NGAY_NANG_CAP As Date?
    Public Property MA_DANH_HIEU As Integer?
    Public Property URL As String
    Public Property NV As Integer?   '0: Khách hàng; 1: Nhân viên; 2: Quản trị hệ thống
End Class

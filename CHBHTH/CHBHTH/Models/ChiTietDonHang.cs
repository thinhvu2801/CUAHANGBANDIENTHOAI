namespace CHBHDT63131330.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Display(Name = "Chi tiết mã đơn hàng")]
        [Key]
        public int CTMaDon { get; set; }

        [Display(Name = "Mã đơn hàng")]
        public int MaDon { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public int MaSP { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal? DonGia { get; set; }

        [Display(Name = "Thành tiền")]
        public decimal? ThanhTien { get; set; }

        [Display(Name = "Phương thức thanh toán")]
        public int? PhuongThucThanhToan { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

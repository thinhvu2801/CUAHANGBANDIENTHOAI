namespace CHBHDT63131330.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Display(Name = "Mã đơn hàng")]
        [Key]
        public int MaDon { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime? NgayDat { get; set; }

        [Display(Name = "Tình trạng đơn hàng")]
        public int? TinhTrang { get; set; }

        [Display(Name = "Hình thức thanh toán")]
        public int? ThanhToan { get; set; }

        [Display(Name = "Địa chỉ nhận hàng")]
        [StringLength(100)]
        public string DiaChiNhanHang { get; set; }

        [Display(Name = "Người đặt")]
        public int? MaNguoiDung { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}

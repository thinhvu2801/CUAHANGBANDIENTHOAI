namespace CHBHDT63131330.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Display(Name = "Mã người dùng")]
        public int MaNguoiDung { get; set; }

        [Display(Name = "Họ & tên")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Họ tên phải từ 5-50 ký tự")]
        [Required]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        [StringLength(50)]
        [Required]
        [EmailAddress(ErrorMessage = "Bạn phải điền email hợp lệ")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [StringLength(50)]
        [Required]
        [Phone]
        public string Dienthoai { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Mật khẩu phải từ 5-50 ký tự")]
        [Required]
        public string Matkhau { get; set; }

        [Display(Name = "ID quyền")]
        public int? IDQuyen { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Địa chỉ phải từ 5-200 ký tự")]
        [Required]
        public string Diachi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        public virtual PhanQuyen PhanQuyen { get; set; }
    }
}

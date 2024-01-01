namespace CHBHDT63131330.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [Display(Name = "Mã tin tức")]
        public int MaTT { get; set; }

        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; }

        [Display(Name = "Nội dung")]
        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }
    }
}

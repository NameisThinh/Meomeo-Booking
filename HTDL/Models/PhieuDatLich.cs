using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("PhieuDatLich")]
    public partial class PhieuDatLich
    {
        [Key]
        [StringLength(50)]
        public string MaPDL { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày Đặt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayDat { get; set; }

        [StringLength(50)]
        public string MaBN { get; set; }

        [StringLength(10)]
        public string MaCV { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày Khám")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayKham { get; set; }

        [Display(Name = "Trạng Thái")]
        public int TrangThai { get; set; }

        [StringLength(50)]
        public string MaCa { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        public virtual CaKham CaKham { get; set; }

        public virtual CTCongViec CTCongViec { get; set; }

    }
}
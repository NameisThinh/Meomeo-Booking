using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        [StringLength(50)]
        public string MaDanhGia { get; set; }

        public string NoiDung { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDanhGia { get; set; }

        [StringLength(50)]
        public string MaBN { get; set; }

        [StringLength(50)]
        public string MaBS { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }
    }
}
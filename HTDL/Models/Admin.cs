using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [StringLength(10)]
        public string MaAd { get; set; }
        [StringLength(250)]
        public string Avt { get; set; }
        [StringLength(250)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(15)]
        public string Sdt { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

    }
}
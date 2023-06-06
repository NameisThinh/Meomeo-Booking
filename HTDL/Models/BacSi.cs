using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("BacSi")]
    public partial class BacSi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BacSi()
        {
            CTCongViecs = new HashSet<CTCongViec>();
            DanhGias = new HashSet<DanhGia>();
        }

        [Key]
        [StringLength(50)]
        public string MaBS { get; set; }
        [StringLength(250)]
        public string Avt { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Bác Sĩ")]
        public string TenBS { get; set; }

        [StringLength(100)]
        [Display(Name = "Ngày Sinh")]
        public string NgaySinh { get; set; }
        [Display(Name = "Giới Tính")]
        public bool? GioiTinh { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string MaKhoa { get; set; }

        [StringLength(50)]
        public string MaCV { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public virtual ChucVu ChucVu { get; set; }

        public virtual Khoa Khoa { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTCongViec> CTCongViecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }
    }
}
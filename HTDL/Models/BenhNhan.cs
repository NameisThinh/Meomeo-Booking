using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("BenhNhan")]
    public partial class BenhNhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BenhNhan()
        {
            DanhGias = new HashSet<DanhGia>();
            PhieuDatLiches = new HashSet<PhieuDatLich>();
        }

        [Key]
        [StringLength(50)]
        public string MaBN { get; set; }
        [StringLength(250)]
        public string Avt { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Bệnh Nhân")]
        public string TenBN { get; set; }
        [StringLength(100)]
        [Display(Name = "Ngày Sinh")]
        public string NgaySinh { get; set; }

        [Display(Name = "Giới Tính")]
        public bool GioiTinh { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatLich> PhieuDatLiches { get; set; }
    }
}
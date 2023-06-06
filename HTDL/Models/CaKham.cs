using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("CaKham")]
    public partial class CaKham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaKham()
        {
            PhieuDatLiches = new HashSet<PhieuDatLich>();
        }

        [Key]
        [StringLength(50)]
        public string MaCa { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Ca")]
        public string TenCa { get; set; }

        [Display(Name ="Thời Gian Bắt Đầu")]

        public TimeSpan? ThoiGianBD { get; set; }

        [Display(Name = "Thời Gian Kết Thúc")]
        public TimeSpan? ThoiGianKT { get; set; }
        [Display(Name = "Số Lượng Tối Đa")]
        public int? SoLuongKham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatLich> PhieuDatLiches { get; set; }
    }
}
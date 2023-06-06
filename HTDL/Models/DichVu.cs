using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            CTCongViecs = new HashSet<CTCongViec>();
        }

        [Key]
        [StringLength(50)]
        [Required]
        public string MaDV { get; set; }
        [Required]
        [StringLength(250)]
        [Display(Name = "Tên Dịch Vụ")]
        public string TenDV { get; set; }
        [Required]
        [Display(Name ="Giá Dịch Vụ")]
        public int? GiaDV { get; set; }

        [StringLength(500)]
        [Display(Name ="Mô Tả")]
        public string MoTa { get; set; }
        [StringLength(500)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTCongViec> CTCongViecs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    [Table("CTCongViec")]
    public partial class CTCongViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CTCongViec()
        {
            PhieuDatLiches = new HashSet<PhieuDatLich>();
        }

        [Key]
        [StringLength(10)]
        public string MaCV { get; set; }

        [StringLength(50)]
        public string MaDV { get; set; }

        [StringLength(50)]
        public string MaBS { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual DichVu DichVu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuDatLich> PhieuDatLiches { get; set; }
    }
}
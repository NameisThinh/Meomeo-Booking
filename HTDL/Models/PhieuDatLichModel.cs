using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    public class PhieuDatLichModel
    {
        public BacSi BacSi { get; set; }
        public DichVu DichVu { get; set; }
        public CaKham CaKham { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [FutureDate]
        public DateTime NgayKham  { get; set; } 
    }
}
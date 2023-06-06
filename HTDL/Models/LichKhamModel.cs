using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    public class LichKhamModel
    {
        public List<CaKham> lsCaKham { get; set; }
        public List<CTCongViec> lsCTCV { get; set; }
        
        public string MaCa { get; set; }

      
        
    }   
}
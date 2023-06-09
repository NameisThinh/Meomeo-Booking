﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HTDL.Models
{
    public class BacSiViewModel
    {
        [Required]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required]
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; }

        [Required]
        [Display(Name = "SDT")]
        public string SDT { get; set; }

        [Display(Name = "Avt")]
        public string Avt { get; set; }

        [Required]
        [Display(Name = "Ma Khoa")]
        public string MaKhoa { get; set; }

        [Required]
        [Display(Name = "Ma CV")]
        public string MaCV { get; set; }

        [Required]
        [Display(Name = "Ma DV")]
        public string MaDV { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
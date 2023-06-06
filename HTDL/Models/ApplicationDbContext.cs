using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HTDL.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BacSi> BacSis { get; set; }
        public DbSet<BenhNhan> BenhNhans { get; set; }
        public DbSet<CaKham> CaKhams { get; set; }
        public DbSet<ChucVu> ChucVus { get; set; }
        public DbSet<CTCongViec> CTCongViecs { get; set; }
        public DbSet<DanhGia> DanhGias { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<PhieuDatLich> PhieuDatLiches { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}
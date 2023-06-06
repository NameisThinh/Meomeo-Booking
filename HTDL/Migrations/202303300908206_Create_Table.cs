namespace HTDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                {
                    MaAd = c.String(nullable: false, maxLength: 10),
                    Avt = c.String(maxLength: 250),
                    HoTen = c.String(nullable: false, maxLength: 250),
                    NgaySinh = c.String(maxLength: 100),
                    GioiTinh = c.Boolean(nullable: false),
                    Sdt = c.String(nullable: false, maxLength: 15),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.MaAd)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId, unique: true, name: "AdminUserIdIndex");

            CreateTable(
                "dbo.BacSi",
                c => new
                {
                    MaBS = c.String(nullable: false, maxLength: 50),
                    Avt = c.String(maxLength: 250),
                    TenBS = c.String(nullable: false, maxLength: 250),
                    NgaySinh = c.String(nullable: false, maxLength: 100),
                    GioiTinh = c.Boolean(nullable: false),
                    SDT = c.String(nullable: false, maxLength: 15),
                    MaKhoa = c.String(nullable: false, maxLength: 50),
                    MaCV = c.String(nullable: false, maxLength: 50),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.MaBS)
                .ForeignKey("dbo.ChucVu", t => t.MaCV)
                .ForeignKey("dbo.Khoa", t => t.MaKhoa)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaCV)
                .Index(t => t.UserId, unique: true, name: "BacSiUserIdIndex");

            CreateTable(
               "dbo.BenhNhan",
               c => new
               {
                   MaBN = c.String(nullable: false, maxLength: 50),
                   Avt = c.String(maxLength: 250),
                   TenBN = c.String(nullable: false, maxLength: 250),
                   GioiTinh = c.Boolean(nullable: false),
                   SDT = c.String(nullable: false, maxLength: 15),
                   DiaChi = c.String(nullable: false, maxLength: 500),
                   UserId = c.String(nullable: false, maxLength: 128),
               })
               .PrimaryKey(t => t.MaBN)
               .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
               .Index(t => t.UserId, unique: true, name: "BenhNhanUserIdIndex");


            CreateTable(
                "dbo.ChucVu",
                c => new
                {
                    MaCV = c.String(nullable: false, maxLength: 50),
                    TenCV = c.String(nullable: false, maxLength: 250),
                })
                .PrimaryKey(t => t.MaCV);

            CreateTable(
                "dbo.CTCaKham",
                c => new
                {
                    MaCTCK = c.String(nullable: false, maxLength: 50),
                    NgayKham = c.DateTime(storeType: "date"),
                    MaBS = c.String(nullable: false, maxLength: 50),
                    MaCa = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.MaCTCK)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.CaKham", t => t.MaCa)
                .Index(t => t.MaBS)
                .Index(t => t.MaCa);

            CreateTable(
                "dbo.CaKham",
                c => new
                {
                    MaCa = c.String(nullable: false, maxLength: 50),
                    TenCa = c.String(nullable: false, maxLength: 250),
                    ThoiGianBD = c.Time(nullable: false, precision: 7),
                    ThoiGianKT = c.Time(nullable: false, precision: 7),
                    SoLuongKham = c.Int(),
                })
                .PrimaryKey(t => t.MaCa);

            CreateTable(
                "dbo.PhieuDatLich",
                c => new
                {
                    MaPDL = c.String(nullable: false, maxLength: 50),
                    NgayDat = c.DateTime(nullable: false, storeType: "date"),
                    MaBN = c.String(nullable: false, maxLength: 50),
                    MaCV = c.String(nullable: false, maxLength: 10),
                    MaCTCK = c.String(nullable: false, maxLength: 50),
                    TrangThai = c.String(nullable: false, maxLength: 10),
                })
                .PrimaryKey(t => t.MaPDL)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .ForeignKey("dbo.CTCaKham", t => t.MaCTCK)
                .ForeignKey("dbo.CTCongViec", t => t.MaCV)
                .Index(t => t.MaBN)
                .Index(t => t.MaCV)
                .Index(t => t.MaCTCK);


            CreateTable(
                "dbo.DanhGia",
                c => new
                {
                    MaDanhGia = c.String(nullable: false, maxLength: 50),
                    NoiDung = c.String(nullable: false),
                    NgayDanhGia = c.DateTime(nullable: false, storeType: "date"),
                    MaBN = c.String(nullable: false, maxLength: 50),
                    MaBS = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.MaDanhGia)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS);

            CreateTable(
                "dbo.CTCongViec",
                c => new
                {
                    MaCV = c.String(nullable: false, maxLength: 10),
                    MaDV = c.String(nullable: false, maxLength: 50),
                    MaBS = c.String(nullable: false, maxLength: 50),
                })
                .PrimaryKey(t => t.MaCV)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.DichVu", t => t.MaDV)
                .Index(t => t.MaDV)
                .Index(t => t.MaBS);

            CreateTable(
                "dbo.DichVu",
                c => new
                {
                    MaDV = c.String(nullable: false, maxLength: 50),
                    TenDV = c.String(nullable: false, maxLength: 250),
                    GiaDV = c.Int(nullable: false),
                    MoTa = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.MaDV);

            CreateTable(
                "dbo.Khoa",
                c => new
                {
                    MaKhoa = c.String(nullable: false, maxLength: 50),
                    TenKhoa = c.String(nullable: false, maxLength: 250),
                })
                .PrimaryKey(t => t.MaKhoa);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BacSi", "MaKhoa", "dbo.Khoa");
            DropForeignKey("dbo.PhieuDatLich", "MaCV", "dbo.CTCongViec");
            DropForeignKey("dbo.CTCongViec", "MaDV", "dbo.DichVu");
            DropForeignKey("dbo.CTCongViec", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.PhieuDatLich", "MaCTCK", "dbo.CTCaKham");
            DropForeignKey("dbo.PhieuDatLich", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.DanhGia", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.DanhGia", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.CTCaKham", "MaCa", "dbo.CaKham");
            DropForeignKey("dbo.CTCaKham", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.BacSi", "MaCV", "dbo.ChucVu");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.CTCongViec", new[] { "MaBS" });
            DropIndex("dbo.CTCongViec", new[] { "MaDV" });
            DropIndex("dbo.DanhGia", new[] { "MaBS" });
            DropIndex("dbo.DanhGia", new[] { "MaBN" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaCTCK" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaCV" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaBN" });
            DropIndex("dbo.CTCaKham", new[] { "MaCa" });
            DropIndex("dbo.CTCaKham", new[] { "MaBS" });
            DropIndex("dbo.BacSi", new[] { "MaCV" });
            DropIndex("dbo.BacSi", new[] { "MaKhoa" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Khoa");
            DropTable("dbo.DichVu");
            DropTable("dbo.CTCongViec");
            DropTable("dbo.DanhGia");
            DropTable("dbo.BenhNhan");
            DropTable("dbo.PhieuDatLich");
            DropTable("dbo.CaKham");
            DropTable("dbo.CTCaKham");
            DropTable("dbo.ChucVu");
            DropTable("dbo.BacSi");
            DropTable("dbo.Admin");
        }
    }
}

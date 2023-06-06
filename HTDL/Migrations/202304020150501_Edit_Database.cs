namespace HTDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Edit_Database : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CTCaKham", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.CTCaKham", "MaCa", "dbo.CaKham");
            DropForeignKey("dbo.PhieuDatLich", "MaCTCK", "dbo.CTCaKham");
            DropIndex("dbo.CTCaKham", new[] { "MaBS" });
            DropIndex("dbo.CTCaKham", new[] { "MaCa" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaCTCK" });
            AddColumn("dbo.PhieuDatLich", "NgayKham", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.PhieuDatLich", "MaCa", c => c.String(maxLength: 50));
            CreateIndex("dbo.PhieuDatLich", "MaCa");
            AddForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham", "MaCa");
            DropColumn("dbo.PhieuDatLich", "MaCTCK");
            DropTable("dbo.CTCaKham");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CTCaKham",
                c => new
                    {
                        MaCTCK = c.String(nullable: false, maxLength: 50),
                        NgayKham = c.DateTime(storeType: "date"),
                        MaBS = c.String(maxLength: 50),
                        MaCa = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaCTCK);
            
            AddColumn("dbo.PhieuDatLich", "MaCTCK", c => c.String(maxLength: 50));
            DropForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham");
            DropIndex("dbo.PhieuDatLich", new[] { "MaCa" });
            DropColumn("dbo.PhieuDatLich", "MaCa");
            DropColumn("dbo.PhieuDatLich", "NgayKham");
            CreateIndex("dbo.PhieuDatLich", "MaCTCK");
            CreateIndex("dbo.CTCaKham", "MaCa");
            CreateIndex("dbo.CTCaKham", "MaBS");
            AddForeignKey("dbo.PhieuDatLich", "MaCTCK", "dbo.CTCaKham", "MaCTCK");
            AddForeignKey("dbo.CTCaKham", "MaCa", "dbo.CaKham", "MaCa");
            AddForeignKey("dbo.CTCaKham", "MaBS", "dbo.BacSi", "MaBS");
        }
    }
}

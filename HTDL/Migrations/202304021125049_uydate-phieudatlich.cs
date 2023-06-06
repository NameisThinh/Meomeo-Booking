namespace HTDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uydatephieudatlich : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhieuDatLich", "TrangThai", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhieuDatLich", "TrangThai", c => c.String(maxLength: 10));
        }
    }
}

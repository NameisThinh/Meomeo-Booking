namespace HTDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeDataTrangThai : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PhieuDatLich", "TrangThai", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PhieuDatLich", "TrangThai", c => c.Boolean(nullable: false));
        }
    }
}

namespace HTDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDichvu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DichVu", "HinhAnh", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DichVu", "HinhAnh");
        }
    }
}

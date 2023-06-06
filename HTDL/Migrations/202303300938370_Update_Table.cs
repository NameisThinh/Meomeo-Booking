namespace HTDL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Table : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BenhNhan", "NgaySinh", c => c.String(maxLength: 100));
            DropColumn("dbo.BenhNhan", "DiaChi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BenhNhan", "DiaChi", c => c.String(maxLength: 500));
            DropColumn("dbo.BenhNhan", "NgaySinh");
        }
    }
}

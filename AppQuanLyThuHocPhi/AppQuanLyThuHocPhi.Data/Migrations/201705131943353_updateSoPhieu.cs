namespace AppQuanLyThuHocPhi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSoPhieu : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PhieuThu");
            AlterColumn("dbo.PhieuThu", "SOPHIEU", c => c.String(nullable: false, maxLength: 12, fixedLength: true, unicode: false));
            AddPrimaryKey("dbo.PhieuThu", "SOPHIEU");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PhieuThu");
            AlterColumn("dbo.PhieuThu", "SOPHIEU", c => c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false));
            AddPrimaryKey("dbo.PhieuThu", "SOPHIEU");
        }
    }
}

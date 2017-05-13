namespace AppQuanLyThuHocPhi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTableSinhVien : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SinhViens", newName: "SinhVien");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SinhVien", newName: "SinhViens");
        }
    }
}

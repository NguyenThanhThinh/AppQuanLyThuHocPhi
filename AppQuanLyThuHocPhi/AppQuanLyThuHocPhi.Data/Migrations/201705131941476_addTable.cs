namespace AppQuanLyThuHocPhi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuThu", "LyDoThu_MaLyDo", "dbo.LyDoThu");
            DropIndex("dbo.PhieuThu", new[] { "LyDoThu_MaLyDo" });
            DropColumn("dbo.PhieuThu", "MaLyDoThu");
            RenameColumn(table: "dbo.PhieuThu", name: "LyDoThu_MaLyDo", newName: "MaLyDoThu");
            AlterColumn("dbo.PhieuThu", "MaLyDoThu", c => c.Int(nullable: false));
            AlterColumn("dbo.NhanVien", "DienThoai", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.NhanVien", "Matkhau", c => c.String(maxLength: 50, unicode: false));
            CreateIndex("dbo.PhieuThu", "MaLyDoThu");
            AddForeignKey("dbo.PhieuThu", "MaLyDoThu", "dbo.LyDoThu", "MaLyDo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuThu", "MaLyDoThu", "dbo.LyDoThu");
            DropIndex("dbo.PhieuThu", new[] { "MaLyDoThu" });
            AlterColumn("dbo.NhanVien", "Matkhau", c => c.String(maxLength: 50));
            AlterColumn("dbo.NhanVien", "DienThoai", c => c.String(maxLength: 20));
            AlterColumn("dbo.PhieuThu", "MaLyDoThu", c => c.Int());
            RenameColumn(table: "dbo.PhieuThu", name: "MaLyDoThu", newName: "LyDoThu_MaLyDo");
            AddColumn("dbo.PhieuThu", "MaLyDoThu", c => c.Int(nullable: false));
            CreateIndex("dbo.PhieuThu", "LyDoThu_MaLyDo");
            AddForeignKey("dbo.PhieuThu", "LyDoThu_MaLyDo", "dbo.LyDoThu", "MaLyDo");
        }
    }
}

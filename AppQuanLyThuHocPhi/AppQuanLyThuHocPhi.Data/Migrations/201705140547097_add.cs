namespace AppQuanLyThuHocPhi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lop",
                c => new
                    {
                        MaLop = c.Int(nullable: false, identity: true),
                        TenLop = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaLop);
            
            CreateTable(
                "dbo.SinhVien",
                c => new
                    {
                        MaSV = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaLop = c.Int(nullable: false),
                        HoSV = c.String(maxLength: 20),
                        TenSV = c.String(maxLength: 20),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.Boolean(nullable: false),
                        DiaChi = c.String(maxLength: 120),
                        DienThoai = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        SoCMT = c.String(maxLength: 20),
                        MaMienGiam = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaSV)
                .ForeignKey("dbo.Lop", t => t.MaLop, cascadeDelete: true)
                .ForeignKey("dbo.MienGiam", t => t.MaMienGiam, cascadeDelete: true)
                .Index(t => t.MaLop)
                .Index(t => t.MaMienGiam);
            
            CreateTable(
                "dbo.MienGiam",
                c => new
                    {
                        MaMienGiam = c.Int(nullable: false, identity: true),
                        TenMienGiam = c.String(maxLength: 100),
                        PhanTram = c.Int(),
                    })
                .PrimaryKey(t => t.MaMienGiam);
            
            CreateTable(
                "dbo.PhieuThu",
                c => new
                    {
                        SOPHIEU = c.String(nullable: false, maxLength: 12, fixedLength: true, unicode: false),
                        Id = c.String(),
                        MaSV = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        HocPhi = c.Int(),
                        MienGiam = c.Int(),
                        ThucThu = c.Int(),
                        NgayThu = c.DateTime(),
                        MaLyDoThu = c.Int(nullable: false),
                        NhanVien_MaNV = c.String(maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.SOPHIEU)
                .ForeignKey("dbo.LyDoThu", t => t.MaLyDoThu, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.NhanVien_MaNV)
                .ForeignKey("dbo.SinhVien", t => t.MaSV)
                .Index(t => t.MaSV)
                .Index(t => t.MaLyDoThu)
                .Index(t => t.NhanVien_MaNV);
            
            CreateTable(
                "dbo.LyDoThu",
                c => new
                    {
                        MaLyDo = c.Int(nullable: false, identity: true),
                        TenLyDo = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaLyDo);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        HoNV = c.String(maxLength: 20),
                        TenNV = c.String(maxLength: 20),
                        NgaySinh = c.DateTime(),
                        GioiTinh = c.Boolean(nullable: false),
                        DiaChi = c.String(maxLength: 120),
                        DienThoai = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100),
                        Matkhau = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuThu", "MaSV", "dbo.SinhVien");
            DropForeignKey("dbo.PhieuThu", "NhanVien_MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuThu", "MaLyDoThu", "dbo.LyDoThu");
            DropForeignKey("dbo.SinhVien", "MaMienGiam", "dbo.MienGiam");
            DropForeignKey("dbo.SinhVien", "MaLop", "dbo.Lop");
            DropIndex("dbo.PhieuThu", new[] { "NhanVien_MaNV" });
            DropIndex("dbo.PhieuThu", new[] { "MaLyDoThu" });
            DropIndex("dbo.PhieuThu", new[] { "MaSV" });
            DropIndex("dbo.SinhVien", new[] { "MaMienGiam" });
            DropIndex("dbo.SinhVien", new[] { "MaLop" });
            DropTable("dbo.NhanVien");
            DropTable("dbo.LyDoThu");
            DropTable("dbo.PhieuThu");
            DropTable("dbo.MienGiam");
            DropTable("dbo.SinhVien");
            DropTable("dbo.Lop");
        }
    }
}

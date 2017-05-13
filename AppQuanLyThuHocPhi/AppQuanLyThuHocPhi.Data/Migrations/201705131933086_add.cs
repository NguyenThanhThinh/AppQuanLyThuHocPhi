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
                "dbo.SinhViens",
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
                        SOPHIEU = c.String(nullable: false, maxLength: 10, fixedLength: true, unicode: false),
                        MaNV = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        MaSV = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        HocPhi = c.Int(),
                        MienGiam = c.Int(),
                        ThucThu = c.Int(),
                        NgayThu = c.DateTime(),
                        MaLyDoThu = c.Int(nullable: false),
                        LyDoThu_MaLyDo = c.Int(),
                    })
                .PrimaryKey(t => t.SOPHIEU)
                .ForeignKey("dbo.LyDoThu", t => t.LyDoThu_MaLyDo)
                .ForeignKey("dbo.NhanVien", t => t.MaNV)
                .ForeignKey("dbo.SinhViens", t => t.MaSV)
                .Index(t => t.MaNV)
                .Index(t => t.MaSV)
                .Index(t => t.LyDoThu_MaLyDo);
            
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
                        DienThoai = c.String(maxLength: 20),
                        Email = c.String(maxLength: 100),
                        Matkhau = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuThu", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.PhieuThu", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.PhieuThu", "LyDoThu_MaLyDo", "dbo.LyDoThu");
            DropForeignKey("dbo.SinhViens", "MaMienGiam", "dbo.MienGiam");
            DropForeignKey("dbo.SinhViens", "MaLop", "dbo.Lop");
            DropIndex("dbo.PhieuThu", new[] { "LyDoThu_MaLyDo" });
            DropIndex("dbo.PhieuThu", new[] { "MaSV" });
            DropIndex("dbo.PhieuThu", new[] { "MaNV" });
            DropIndex("dbo.SinhViens", new[] { "MaMienGiam" });
            DropIndex("dbo.SinhViens", new[] { "MaLop" });
            DropTable("dbo.NhanVien");
            DropTable("dbo.LyDoThu");
            DropTable("dbo.PhieuThu");
            DropTable("dbo.MienGiam");
            DropTable("dbo.SinhViens");
            DropTable("dbo.Lop");
        }
    }
}

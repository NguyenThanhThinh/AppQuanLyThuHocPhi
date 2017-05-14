namespace AppQuanLyThuHocPhi.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addProcLop : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("InsertLOP", n => new
            {
                TenLop = n.String(),
                Err = n.String()

            },
            @"if(@TenLop in(Select [TenLop] from [LOP]))
	 begin
		 set @Err=N'Trùng giá trị trường tên lớp'
		 return 
	 end
	 Insert into [LOP] values(@TenLop)
	 set @Err=''"
            );
        }

        public override void Down()
        {
            DropStoredProcedure("InsertLOP");
        }
    }
}

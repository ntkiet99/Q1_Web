namespace QuanLyDatNen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenNen = c.String(),
                        DienTich = c.String(),
                        GiaTri = c.Single(nullable: false),
                        TinhTrang = c.Int(nullable: false),
                        DiaChi = c.String(),
                        GhiChu = c.String(),
                        HoTen = c.String(),
                        CMND = c.String(),
                        NgayKy = c.DateTime(nullable: false),
                        SDT = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nens");
        }
    }
}

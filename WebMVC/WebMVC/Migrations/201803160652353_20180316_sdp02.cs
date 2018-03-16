namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180316_sdp02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProductNum = c.String(maxLength: 100, storeType: "nvarchar"),
                        ProductName = c.String(maxLength: 150, storeType: "nvarchar"),
                        StoreNum = c.Int(nullable: false),
                        version = c.Binary(),
                        Delflag = c.Int(nullable: false),
                        CDate = c.DateTime(nullable: false, precision: 0),
                        AccountId = c.String(maxLength: 50, storeType: "nvarchar"),
                        AccountName = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductInfoes");
        }
    }
}

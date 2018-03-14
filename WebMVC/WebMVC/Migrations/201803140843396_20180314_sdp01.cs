namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180314_sdp01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FileName = c.String(maxLength: 200, storeType: "nvarchar"),
                        FileType = c.String(maxLength: 50, storeType: "nvarchar"),
                        RelativePath = c.String(maxLength: 500, storeType: "nvarchar"),
                        FileSize = c.Long(nullable: false),
                        AccountId = c.String(maxLength: 100, storeType: "nvarchar"),
                        AccountName = c.String(maxLength: 100, storeType: "nvarchar"),
                        CDate = c.DateTime(nullable: false, precision: 0),
                        Delflag = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageInfoes");
        }
    }
}

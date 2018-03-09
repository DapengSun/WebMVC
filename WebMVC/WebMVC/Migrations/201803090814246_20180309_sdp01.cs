namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180309_sdp01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Content = c.String(unicode: false),
                        CDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogInfoes");
        }
    }
}

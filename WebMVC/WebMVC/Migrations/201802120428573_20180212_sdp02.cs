namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180212_sdp02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogsInfo",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        BlogHeading = c.String(maxLength: 200, storeType: "nvarchar"),
                        BlogSubHeading = c.String(maxLength: 200, storeType: "nvarchar"),
                        BlogAuthor = c.String(maxLength: 200, storeType: "nvarchar"),
                        BlogsSurfacePlot = c.String(maxLength: 200, storeType: "nvarchar"),
                        BlogContent = c.String(unicode: false),
                        Delflag = c.Int(nullable: false),
                        CDate = c.DateTime(nullable: false, precision: 0),
                        UDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogsInfo");
        }
    }
}

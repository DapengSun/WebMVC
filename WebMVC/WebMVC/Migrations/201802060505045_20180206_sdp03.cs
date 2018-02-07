namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180206_sdp03 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TestClasses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        KeyId = c.Int(nullable: false),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

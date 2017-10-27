namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s2 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FilmInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilmInfoes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _id = c.Int(nullable: false, identity: true),
                        FilmId = c.Int(nullable: false),
                        FilmName = c.String(unicode: false),
                        newtest = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

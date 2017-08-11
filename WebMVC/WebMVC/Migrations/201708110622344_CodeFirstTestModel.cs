namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstTestModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeFirstTestModel",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _id = c.Int(nullable: false, identity: true),
                        TestName = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CodeFirstTestModel");
        }
    }
}

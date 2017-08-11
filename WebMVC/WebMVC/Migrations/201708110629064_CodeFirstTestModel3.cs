namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstTestModel3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CodeFirstTestModel", "TestName2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CodeFirstTestModel", "TestName2", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
    }
}

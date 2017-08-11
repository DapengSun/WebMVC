namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstTestModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodeFirstTestModel", "TestName2", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CodeFirstTestModel", "TestName2");
        }
    }
}

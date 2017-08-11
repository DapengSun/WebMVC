namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeFirstTestModel5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CodeFirstTestModel", "Namerr", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CodeFirstTestModel", "Namerr");
        }
    }
}

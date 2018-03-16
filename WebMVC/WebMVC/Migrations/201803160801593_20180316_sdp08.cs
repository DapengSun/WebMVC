namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180316_sdp08 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductInfoes", "StoreNum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInfoes", "StoreNum", c => c.Int(nullable: false));
        }
    }
}

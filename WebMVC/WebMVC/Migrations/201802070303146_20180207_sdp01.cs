namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180207_sdp01 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "_id", c => c.Int(nullable: false, identity: true));
        }
    }
}

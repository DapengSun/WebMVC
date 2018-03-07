namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180226_sdp01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogsInfo", "LikeNum", c => c.Int(nullable: false));
            AddColumn("dbo.BlogsInfo", "CommentNum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogsInfo", "CommentNum");
            DropColumn("dbo.BlogsInfo", "LikeNum");
        }
    }
}

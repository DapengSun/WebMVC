namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171027_sdp02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "NickName", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "NickName", c => c.String(unicode: false));
        }
    }
}

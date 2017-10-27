namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171027_sdp01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _id = c.Int(nullable: false, identity: true),
                        Role = c.Int(nullable: false),
                        LoginName = c.String(maxLength: 50, storeType: "nvarchar"),
                        NickName = c.String(unicode: false),
                        Phone = c.String(maxLength: 15, storeType: "nvarchar"),
                        Password = c.String(maxLength: 50, storeType: "nvarchar"),
                        NikeName = c.String(maxLength: 30, storeType: "nvarchar"),
                        Sex = c.Int(nullable: false),
                        LastDate = c.DateTime(nullable: false, precision: 0),
                        CDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfiles");
        }
    }
}

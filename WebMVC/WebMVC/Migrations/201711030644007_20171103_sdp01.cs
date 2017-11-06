namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171103_sdp01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BTC_Price",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _Id = c.Int(nullable: false, identity: true),
                        LastPriceUSD = c.Single(nullable: false),
                        DailyChange = c.Single(nullable: false),
                        DailyChangePercent = c.Single(nullable: false),
                        DaysLow = c.Single(nullable: false),
                        DaysHigh = c.Single(nullable: false),
                        DaysOpen = c.Single(nullable: false),
                        DaysVolume = c.Int(nullable: false),
                        CDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BTC_Price");
        }
    }
}

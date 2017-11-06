namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171103_sdp03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BTC_Price_Statistics",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        _Id = c.Int(nullable: false, identity: true),
                        LastPriceUSD = c.Single(),
                        DailyChange = c.Single(),
                        DailyChangePercent = c.Single(),
                        DaysLow = c.Single(),
                        DaysHigh = c.Single(),
                        DaysOpen = c.Single(),
                        DaysVolume = c.Int(),
                        CDate = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BTC_Price_Statistics");
        }
    }
}

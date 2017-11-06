namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171103_sdp02 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BTC_Price", "LastPriceUSD", c => c.Single());
            AlterColumn("dbo.BTC_Price", "DailyChange", c => c.Single());
            AlterColumn("dbo.BTC_Price", "DailyChangePercent", c => c.Single());
            AlterColumn("dbo.BTC_Price", "DaysLow", c => c.Single());
            AlterColumn("dbo.BTC_Price", "DaysHigh", c => c.Single());
            AlterColumn("dbo.BTC_Price", "DaysOpen", c => c.Single());
            AlterColumn("dbo.BTC_Price", "DaysVolume", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BTC_Price", "DaysVolume", c => c.Int(nullable: false));
            AlterColumn("dbo.BTC_Price", "DaysOpen", c => c.Single(nullable: false));
            AlterColumn("dbo.BTC_Price", "DaysHigh", c => c.Single(nullable: false));
            AlterColumn("dbo.BTC_Price", "DaysLow", c => c.Single(nullable: false));
            AlterColumn("dbo.BTC_Price", "DailyChangePercent", c => c.Single(nullable: false));
            AlterColumn("dbo.BTC_Price", "DailyChange", c => c.Single(nullable: false));
            AlterColumn("dbo.BTC_Price", "LastPriceUSD", c => c.Single(nullable: false));
        }
    }
}

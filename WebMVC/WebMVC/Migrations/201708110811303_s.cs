namespace WebMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class s : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "spiderdb.houseinfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HouseTitle = c.String(maxLength: 100, storeType: "nvarchar"),
                        HouseName = c.String(maxLength: 100, storeType: "nvarchar"),
                        HousePattern = c.String(maxLength: 50, storeType: "nvarchar"),
                        HouseRange = c.String(maxLength: 50, storeType: "nvarchar"),
                        HouseFace = c.String(maxLength: 50, storeType: "nvarchar"),
                        HouseStyle = c.String(maxLength: 50, storeType: "nvarchar"),
                        IsElevator = c.String(maxLength: 30, storeType: "nvarchar"),
                        HousePosition = c.String(maxLength: 150, storeType: "nvarchar"),
                        HouseArea = c.String(maxLength: 150, storeType: "nvarchar"),
                        HouseLike = c.String(maxLength: 50, storeType: "nvarchar"),
                        HouseLook = c.String(maxLength: 50, storeType: "nvarchar"),
                        HouseReleaseDate = c.String(maxLength: 50, storeType: "nvarchar"),
                        traffic = c.String(maxLength: 150, storeType: "nvarchar"),
                        taxfree = c.String(maxLength: 50, storeType: "nvarchar"),
                        haskey = c.String(maxLength: 50, storeType: "nvarchar"),
                        HouseTotalPrice = c.String(maxLength: 50, storeType: "nvarchar"),
                        HousePrice = c.String(maxLength: 50, storeType: "nvarchar"),
                        CDate = c.DateTime(precision: 0),
                        Delflag = c.Int(),
                        TotalPriceUnit = c.String(maxLength: 20, storeType: "nvarchar"),
                        PriceUnit = c.String(maxLength: 20, storeType: "nvarchar"),
                        HouseRangeNum = c.Single(),
                        HouseLikeNum = c.Int(),
                        HouseLookNum = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("spiderdb.houseinfo");
        }
    }
}

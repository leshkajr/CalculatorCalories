namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDietForTheDay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DietForTheDays",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DietForTheDayProducts",
                c => new
                    {
                        DietForTheDay_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DietForTheDay_id, t.Product_id })
                .ForeignKey("dbo.DietForTheDays", t => t.DietForTheDay_id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_id, cascadeDelete: true)
                .Index(t => t.DietForTheDay_id)
                .Index(t => t.Product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DietForTheDayProducts", "Product_id", "dbo.Products");
            DropForeignKey("dbo.DietForTheDayProducts", "DietForTheDay_id", "dbo.DietForTheDays");
            DropIndex("dbo.DietForTheDayProducts", new[] { "Product_id" });
            DropIndex("dbo.DietForTheDayProducts", new[] { "DietForTheDay_id" });
            DropTable("dbo.DietForTheDayProducts");
            DropTable("dbo.DietForTheDays");
        }
    }
}

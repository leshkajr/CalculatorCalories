namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addV10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DietForTheDayProducts", "DietForTheDay_id", "dbo.DietForTheDays");
            DropForeignKey("dbo.DietForTheDayProducts", "Product_id", "dbo.Products");
            DropIndex("dbo.DietForTheDayProducts", new[] { "DietForTheDay_id" });
            DropIndex("dbo.DietForTheDayProducts", new[] { "Product_id" });
            AddColumn("dbo.Products", "DietForTheDayId", c => c.Int());
            CreateIndex("dbo.Products", "DietForTheDayId");
            AddForeignKey("dbo.Products", "DietForTheDayId", "dbo.DietForTheDays", "id");
            DropTable("dbo.DietForTheDayProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DietForTheDayProducts",
                c => new
                    {
                        DietForTheDay_id = c.Int(nullable: false),
                        Product_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DietForTheDay_id, t.Product_id });
            
            DropForeignKey("dbo.Products", "DietForTheDayId", "dbo.DietForTheDays");
            DropIndex("dbo.Products", new[] { "DietForTheDayId" });
            DropColumn("dbo.Products", "DietForTheDayId");
            CreateIndex("dbo.DietForTheDayProducts", "Product_id");
            CreateIndex("dbo.DietForTheDayProducts", "DietForTheDay_id");
            AddForeignKey("dbo.DietForTheDayProducts", "Product_id", "dbo.Products", "id", cascadeDelete: true);
            AddForeignKey("dbo.DietForTheDayProducts", "DietForTheDay_id", "dbo.DietForTheDays", "id", cascadeDelete: true);
        }
    }
}

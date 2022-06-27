namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDoubleNutrition : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Protein", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Fats", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Carbohydrates", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "Calories", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Calories", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Carbohydrates", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Fats", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Protein", c => c.Int(nullable: false));
        }
    }
}

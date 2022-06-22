namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProductCalories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Calories", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Calories");
        }
    }
}

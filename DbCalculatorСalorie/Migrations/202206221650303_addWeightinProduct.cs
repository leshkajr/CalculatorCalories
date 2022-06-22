namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addWeightinProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Weight", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Weight");
        }
    }
}

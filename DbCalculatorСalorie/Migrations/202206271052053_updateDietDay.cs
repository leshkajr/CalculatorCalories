namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDietDay : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DietForTheDays", new[] { "UserId" });
            CreateIndex("dbo.DietForTheDays", "userId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DietForTheDays", new[] { "userId" });
            CreateIndex("dbo.DietForTheDays", "UserId");
        }
    }
}

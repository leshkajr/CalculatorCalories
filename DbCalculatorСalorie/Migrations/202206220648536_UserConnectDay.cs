namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserConnectDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DietForTheDays", "UserId", c => c.Int());
            CreateIndex("dbo.DietForTheDays", "UserId");
            AddForeignKey("dbo.DietForTheDays", "UserId", "dbo.Users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DietForTheDays", "UserId", "dbo.Users");
            DropIndex("dbo.DietForTheDays", new[] { "UserId" });
            DropColumn("dbo.DietForTheDays", "UserId");
        }
    }
}

namespace DbCalculatorСalorie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDecimalDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Weight", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "Height", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Height", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

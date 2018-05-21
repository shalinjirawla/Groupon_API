namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thirteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cart", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "Status", c => c.Int(nullable: false));
        }
    }
}

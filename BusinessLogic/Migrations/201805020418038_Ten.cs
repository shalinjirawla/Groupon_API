namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ten : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DealCode", "Description", c => c.String());
            AddColumn("dbo.DealCode", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DealCode", "Status");
            DropColumn("dbo.DealCode", "Description");
        }
    }
}

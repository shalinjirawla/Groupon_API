namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifteen : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cart", "DealID", c => c.Guid());
            AlterColumn("dbo.Cart", "OfferID", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "OfferID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cart", "DealID", c => c.Guid(nullable: false));
        }
    }
}

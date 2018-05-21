namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourteen : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "DealID", "dbo.Deal");
            DropIndex("dbo.Cart", new[] { "DealID" });
            AddColumn("dbo.Cart", "OfferID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cart", "PaymentType", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cart", "PaymentType", c => c.Int(nullable: false));
            DropColumn("dbo.Cart", "OfferID");
            CreateIndex("dbo.Cart", "DealID");
            AddForeignKey("dbo.Cart", "DealID", "dbo.Deal", "ID", cascadeDelete: true);
        }
    }
}

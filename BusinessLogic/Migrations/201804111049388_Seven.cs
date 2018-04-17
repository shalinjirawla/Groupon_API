namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seven : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentDetail", "OfferStatus", c => c.Boolean());
            AlterColumn("dbo.Offers", "Count", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Offers", "Count", c => c.Int(nullable: false));
            DropColumn("dbo.PaymentDetail", "OfferStatus");
        }
    }
}

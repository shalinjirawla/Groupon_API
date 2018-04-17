namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentDetail", "OfferID", c => c.Guid());
            DropColumn("dbo.PaymentDetail", "OfferStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PaymentDetail", "OfferStatus", c => c.Boolean());
            DropColumn("dbo.PaymentDetail", "OfferID");
        }
    }
}

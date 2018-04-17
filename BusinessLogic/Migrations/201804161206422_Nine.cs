namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PaymentDetail", "ExpiryDate", c => c.DateTime());
            AlterColumn("dbo.PaymentDetail", "CVV", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentDetail", "CVV", c => c.Int(nullable: false));
            AlterColumn("dbo.PaymentDetail", "ExpiryDate", c => c.DateTime(nullable: false));
        }
    }
}

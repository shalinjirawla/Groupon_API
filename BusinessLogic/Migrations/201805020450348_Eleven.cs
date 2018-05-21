namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eleven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FirstCouponCode",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        Code = c.String(),
                        PaymentDetailID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PaymentDetail", t => t.PaymentDetailID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.PaymentDetailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FirstCouponCode", "UserID", "dbo.User");
            DropForeignKey("dbo.FirstCouponCode", "PaymentDetailID", "dbo.PaymentDetail");
            DropIndex("dbo.FirstCouponCode", new[] { "PaymentDetailID" });
            DropIndex("dbo.FirstCouponCode", new[] { "UserID" });
            DropTable("dbo.FirstCouponCode");
        }
    }
}

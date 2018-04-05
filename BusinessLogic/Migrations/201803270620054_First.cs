namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        Qty = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CouponCode = c.String(),
                        PaymentType = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.DealID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Deal",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        UserID = c.Guid(nullable: false),
                        URL = c.String(),
                        LocationID = c.Guid(nullable: false),
                        Details = c.String(),
                        FinePrint = c.String(),
                        Image = c.String(),
                        CategoryID = c.Guid(nullable: false),
                        TotalQty = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.LocationID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        LocationName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        EmailID = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 6),
                        LocationID = c.Guid(nullable: false),
                        DOB = c.DateTime(),
                        Category = c.Guid(nullable: false),
                        Image = c.String(),
                        GoogleID = c.String(),
                        GoogleName = c.String(maxLength: 50),
                        FacebookID = c.String(),
                        FacebookName = c.String(maxLength: 50),
                        RegisteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.DealCode",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Code = c.String(),
                        LocationID = c.Guid(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedDate = c.DateTime(nullable: false),
                        Validitydate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.DealID)
                .Index(t => t.UserID)
                .Index(t => t.LocationID);
            
            CreateTable(
                "dbo.DealLike",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        LikedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.DealID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.DealOrder",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        OrderNumber = c.Guid(nullable: false),
                        DealOrderDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.DealID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.DealReview",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        ReviewText = c.String(maxLength: 500),
                        Rating = c.Int(nullable: false),
                        UserID = c.Guid(nullable: false),
                        ReviewDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.DealID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        CreatedTime = c.DateTime(nullable: false),
                        Message = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .Index(t => t.DealID);
            
            CreateTable(
                "dbo.PaymentDetail",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        DealID = c.Guid(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        CardNumber = c.String(),
                        CardName = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        CVV = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.DealID);
            
            CreateTable(
                "dbo.SendGift",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        FromUserID = c.Guid(nullable: false),
                        RecepientEmail = c.String(),
                        Message = c.String(),
                        DealID = c.Guid(nullable: false),
                        DateToSend = c.DateTime(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.FromUserID, cascadeDelete: true)
                .Index(t => t.FromUserID)
                .Index(t => t.DealID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SendGift", "FromUserID", "dbo.User");
            DropForeignKey("dbo.SendGift", "DealID", "dbo.Deal");
            DropForeignKey("dbo.PaymentDetail", "UserID", "dbo.User");
            DropForeignKey("dbo.PaymentDetail", "DealID", "dbo.Deal");
            DropForeignKey("dbo.Notification", "DealID", "dbo.Deal");
            DropForeignKey("dbo.DealReview", "UserID", "dbo.User");
            DropForeignKey("dbo.DealReview", "DealID", "dbo.Deal");
            DropForeignKey("dbo.DealOrder", "UserID", "dbo.User");
            DropForeignKey("dbo.DealOrder", "DealID", "dbo.Deal");
            DropForeignKey("dbo.DealLike", "UserID", "dbo.User");
            DropForeignKey("dbo.DealLike", "DealID", "dbo.Deal");
            DropForeignKey("dbo.DealCode", "UserID", "dbo.User");
            DropForeignKey("dbo.DealCode", "LocationID", "dbo.Location");
            DropForeignKey("dbo.DealCode", "DealID", "dbo.Deal");
            DropForeignKey("dbo.Cart", "UserID", "dbo.User");
            DropForeignKey("dbo.Cart", "DealID", "dbo.Deal");
            DropForeignKey("dbo.Deal", "UserID", "dbo.User");
            DropForeignKey("dbo.User", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Deal", "LocationID", "dbo.Location");
            DropForeignKey("dbo.Deal", "CategoryID", "dbo.Category");
            DropIndex("dbo.SendGift", new[] { "DealID" });
            DropIndex("dbo.SendGift", new[] { "FromUserID" });
            DropIndex("dbo.PaymentDetail", new[] { "DealID" });
            DropIndex("dbo.PaymentDetail", new[] { "UserID" });
            DropIndex("dbo.Notification", new[] { "DealID" });
            DropIndex("dbo.DealReview", new[] { "UserID" });
            DropIndex("dbo.DealReview", new[] { "DealID" });
            DropIndex("dbo.DealOrder", new[] { "UserID" });
            DropIndex("dbo.DealOrder", new[] { "DealID" });
            DropIndex("dbo.DealLike", new[] { "UserID" });
            DropIndex("dbo.DealLike", new[] { "DealID" });
            DropIndex("dbo.DealCode", new[] { "LocationID" });
            DropIndex("dbo.DealCode", new[] { "UserID" });
            DropIndex("dbo.DealCode", new[] { "DealID" });
            DropIndex("dbo.User", new[] { "LocationID" });
            DropIndex("dbo.Deal", new[] { "CategoryID" });
            DropIndex("dbo.Deal", new[] { "LocationID" });
            DropIndex("dbo.Deal", new[] { "UserID" });
            DropIndex("dbo.Cart", new[] { "UserID" });
            DropIndex("dbo.Cart", new[] { "DealID" });
            DropTable("dbo.Status");
            DropTable("dbo.SendGift");
            DropTable("dbo.PaymentDetail");
            DropTable("dbo.Notification");
            DropTable("dbo.DealReview");
            DropTable("dbo.DealOrder");
            DropTable("dbo.DealLike");
            DropTable("dbo.DealCode");
            DropTable("dbo.User");
            DropTable("dbo.Location");
            DropTable("dbo.Category");
            DropTable("dbo.Deal");
            DropTable("dbo.Cart");
        }
    }
}

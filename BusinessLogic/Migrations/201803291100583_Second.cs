namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DealRecom",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        AverageRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalReviews = c.Int(nullable: false),
                        TotalLikes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .Index(t => t.DealID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealRecom", "DealID", "dbo.Deal");
            DropIndex("dbo.DealRecom", new[] { "DealID" });
            DropTable("dbo.DealRecom");
        }
    }
}

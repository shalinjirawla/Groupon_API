namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DealRecom", "AverageRating", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.DealRecom", "TotalReviews", c => c.Int());
            AlterColumn("dbo.DealRecom", "TotalLikes", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DealRecom", "TotalLikes", c => c.Int(nullable: false));
            AlterColumn("dbo.DealRecom", "TotalReviews", c => c.Int(nullable: false));
            AlterColumn("dbo.DealRecom", "AverageRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}

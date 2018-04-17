namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Five : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        ID = c.Guid(nullable: false, identity: true),
                        DealID = c.Guid(nullable: false),
                        Text = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
                .Index(t => t.DealID);
            
            AddColumn("dbo.Deal", "DealSold", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "DealID", "dbo.Deal");
            DropIndex("dbo.Offers", new[] { "DealID" });
            DropColumn("dbo.Deal", "DealSold");
            DropTable("dbo.Offers");
        }
    }
}

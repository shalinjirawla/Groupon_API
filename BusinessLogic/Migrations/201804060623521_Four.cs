namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Four : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.DealSoldCounter",
            //    c => new
            //    {
            //        ID = c.Guid(nullable: false, identity: true),
            //        DealID = c.Guid(nullable: false),
            //        Count = c.Int(nullable: false),
            //    })
            //    .PrimaryKey(t => t.ID)
            //    .ForeignKey("dbo.Deal", t => t.DealID, cascadeDelete: true)
            //    .Index(t => t.DealID);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DealSoldCounter", "DealID", "dbo.Deal");
            DropIndex("dbo.DealSoldCounter", new[] { "DealID" });
            DropTable("dbo.DealSoldCounter");
        }
    }
}

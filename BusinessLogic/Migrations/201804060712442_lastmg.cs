namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastmg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DealSoldCounter", "DealID", "dbo.Deal");
            DropIndex("dbo.DealSoldCounter", new[] { "DealID" });
            DropTable("dbo.DealSoldCounter");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.DealSoldCounter",
            //    c => new
            //        {
            //            ID = c.Guid(nullable: false, identity: true),
            //            DealID = c.Guid(nullable: false),
            //            Count = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);
            
            //CreateIndex("dbo.DealSoldCounter", "DealID");
            //AddForeignKey("dbo.DealSoldCounter", "DealID", "dbo.Deal", "ID", cascadeDelete: true);
        }
    }
}

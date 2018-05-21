namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Twelve : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DealCode", "DealID", "dbo.Deal");
            DropForeignKey("dbo.DealCode", "LocationID", "dbo.Location");
            DropForeignKey("dbo.DealCode", "UserID", "dbo.User");
            DropIndex("dbo.DealCode", new[] { "DealID" });
            DropIndex("dbo.DealCode", new[] { "UserID" });
            DropIndex("dbo.DealCode", new[] { "LocationID" });
            AlterColumn("dbo.DealCode", "DealID", c => c.Guid());
            AlterColumn("dbo.DealCode", "UserID", c => c.Guid());
            AlterColumn("dbo.DealCode", "LocationID", c => c.Guid());
            AlterColumn("dbo.DealCode", "Validitydate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DealCode", "Validitydate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DealCode", "LocationID", c => c.Guid(nullable: false));
            AlterColumn("dbo.DealCode", "UserID", c => c.Guid(nullable: false));
            AlterColumn("dbo.DealCode", "DealID", c => c.Guid(nullable: false));
            CreateIndex("dbo.DealCode", "LocationID");
            CreateIndex("dbo.DealCode", "UserID");
            CreateIndex("dbo.DealCode", "DealID");
            AddForeignKey("dbo.DealCode", "UserID", "dbo.User", "ID", cascadeDelete: true);
            AddForeignKey("dbo.DealCode", "LocationID", "dbo.Location", "ID");
            AddForeignKey("dbo.DealCode", "DealID", "dbo.Deal", "ID", cascadeDelete: true);
        }
    }
}

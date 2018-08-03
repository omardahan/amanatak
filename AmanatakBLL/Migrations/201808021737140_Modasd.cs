namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modasd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemMissings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemDetails = c.String(nullable: false),
                        UserType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Items", "DeliveryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Items", "DeliveryPerosnName", c => c.String());
            AddColumn("dbo.ItemImages", "ItemMissingId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemImages", "ItemMissingId");
            AddForeignKey("dbo.ItemImages", "ItemMissingId", "dbo.ItemMissings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemImages", "ItemMissingId", "dbo.ItemMissings");
            DropIndex("dbo.ItemImages", new[] { "ItemMissingId" });
            DropColumn("dbo.ItemImages", "ItemMissingId");
            DropColumn("dbo.Items", "DeliveryPerosnName");
            DropColumn("dbo.Items", "DeliveryDate");
            DropTable("dbo.ItemMissings");
        }
    }
}

namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemImages", "ItemMissingId", "dbo.ItemMissings");
            DropForeignKey("dbo.ItemMissings", "ItemTypeId", "dbo.ItemTypes");
            DropForeignKey("dbo.Items", "ItemMissingId", "dbo.ItemMissings");
            DropIndex("dbo.Items", new[] { "ItemMissingId" });
            DropIndex("dbo.ItemImages", new[] { "ItemMissingId" });
            DropIndex("dbo.ItemMissings", new[] { "ItemTypeId" });
            DropColumn("dbo.Items", "ItemMissingId");
            DropColumn("dbo.ItemImages", "ItemMissingId");
            DropTable("dbo.ItemMissings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemMissings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemTypeId = c.Int(nullable: false),
                        ItemDetails = c.String(),
                        UserType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ItemImages", "ItemMissingId", c => c.Int(nullable: false));
            AddColumn("dbo.Items", "ItemMissingId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemMissings", "ItemTypeId");
            CreateIndex("dbo.ItemImages", "ItemMissingId");
            CreateIndex("dbo.Items", "ItemMissingId");
            AddForeignKey("dbo.Items", "ItemMissingId", "dbo.ItemMissings", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemMissings", "ItemTypeId", "dbo.ItemTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemImages", "ItemMissingId", "dbo.ItemMissings", "Id", cascadeDelete: true);
        }
    }
}

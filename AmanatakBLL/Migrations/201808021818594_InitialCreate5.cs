namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Histories", "ItemId", "dbo.Items");
            DropIndex("dbo.Histories", new[] { "ItemId" });
            CreateTable(
                "dbo.ItemsHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ItemMissingId = c.Int(nullable: false),
                        DeliveryTime = c.DateTime(nullable: false),
                        DeliveryNamePerson = c.String(),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Histories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ItemsHistories");
            CreateIndex("dbo.Histories", "ItemId");
            AddForeignKey("dbo.Histories", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
    }
}

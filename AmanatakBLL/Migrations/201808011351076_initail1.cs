namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail1 : DbMigration
    {
        public override void Up()
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
                        AppModified = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SerialNumber = c.Int(nullable: false),
                        ItemTypeId = c.Int(nullable: false),
                        ItemDetails = c.String(),
                        UserType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        AppModified = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemTypes", t => t.ItemTypeId, cascadeDelete: true)
                .Index(t => t.ItemTypeId);
            
            CreateTable(
                "dbo.ItemTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        AppModified = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TypeId = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "ItemTypeId", "dbo.ItemTypes");
            DropIndex("dbo.Items", new[] { "ItemTypeId" });
            DropIndex("dbo.Histories", new[] { "ItemId" });
            DropTable("dbo.TestClasses");
            DropTable("dbo.ItemTypes");
            DropTable("dbo.Items");
            DropTable("dbo.Histories");
        }
    }
}

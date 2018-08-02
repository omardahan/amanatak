namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initail2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        ImagePath = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            DropColumn("dbo.Histories", "AppModified");
            DropColumn("dbo.Items", "AppModified");
            DropColumn("dbo.ItemTypes", "AppModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemTypes", "AppModified", c => c.String());
            AddColumn("dbo.Items", "AppModified", c => c.String());
            AddColumn("dbo.Histories", "AppModified", c => c.String());
            DropForeignKey("dbo.ItemImages", "ItemId", "dbo.Items");
            DropIndex("dbo.ItemImages", new[] { "ItemId" });
            DropTable("dbo.ItemImages");
        }
    }
}

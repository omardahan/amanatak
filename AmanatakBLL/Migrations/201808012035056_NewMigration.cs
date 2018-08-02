namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConversationMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConversationId = c.Int(nullable: false),
                        Message = c.String(),
                        UserType = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .Index(t => t.ConversationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConversationMessages", "ConversationId", "dbo.Conversations");
            DropIndex("dbo.ConversationMessages", new[] { "ConversationId" });
            DropTable("dbo.ConversationMessages");
            DropTable("dbo.Conversations");
        }
    }
}

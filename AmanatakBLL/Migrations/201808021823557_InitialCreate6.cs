namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemsHistories", "Details", c => c.String());
            AlterColumn("dbo.ItemsHistories", "ItemId", c => c.Int());
            AlterColumn("dbo.ItemsHistories", "ItemMissingId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemsHistories", "ItemMissingId", c => c.Int(nullable: false));
            AlterColumn("dbo.ItemsHistories", "ItemId", c => c.Int(nullable: false));
            DropColumn("dbo.ItemsHistories", "Details");
        }
    }
}

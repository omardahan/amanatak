namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verion3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ItemView", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "ItemView");
        }
    }
}

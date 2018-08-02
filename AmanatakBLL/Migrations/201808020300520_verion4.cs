namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verion4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Deliveried", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Deliveried");
        }
    }
}

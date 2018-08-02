namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPerson : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Name", c => c.String(nullable: false));
        }
    }
}

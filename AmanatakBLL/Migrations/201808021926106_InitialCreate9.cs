namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemOwners", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemOwners", "FirstName", c => c.String(nullable: false));
        }
    }
}

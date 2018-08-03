namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ItemOwners", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ItemOwners", "LastName", c => c.String(nullable: false));
        }
    }
}

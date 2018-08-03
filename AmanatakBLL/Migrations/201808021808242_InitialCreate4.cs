namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "DeliveryDate");
            DropColumn("dbo.Items", "DeliveryPerosnName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "DeliveryPerosnName", c => c.String());
            AddColumn("dbo.Items", "DeliveryDate", c => c.DateTime(nullable: false));
        }
    }
}

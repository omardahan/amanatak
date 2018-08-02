namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "AdressFound", c => c.String());
            AlterColumn("dbo.Items", "SerialNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "SerialNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "AdressFound");
        }
    }
}

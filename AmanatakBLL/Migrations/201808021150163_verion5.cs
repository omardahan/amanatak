namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class verion5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ItemOwners", "MiddleName");
            DropColumn("dbo.ItemOwners", "FatherName");
            DropColumn("dbo.ItemOwners", "MotherName");
            DropColumn("dbo.ItemOwners", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ItemOwners", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.ItemOwners", "MotherName", c => c.String());
            AddColumn("dbo.ItemOwners", "FatherName", c => c.String());
            AddColumn("dbo.ItemOwners", "MiddleName", c => c.String());
        }
    }
}

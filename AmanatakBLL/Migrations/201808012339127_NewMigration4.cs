namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemOwners", "Nationality_Id", "dbo.Countries");
            DropIndex("dbo.ItemOwners", new[] { "Nationality_Id" });
            RenameColumn(table: "dbo.ItemOwners", name: "Nationality_Id", newName: "NationalityId");
            AlterColumn("dbo.ItemOwners", "NationalityId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemOwners", "NationalityId");
            AddForeignKey("dbo.ItemOwners", "NationalityId", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOwners", "NationalityId", "dbo.Countries");
            DropIndex("dbo.ItemOwners", new[] { "NationalityId" });
            AlterColumn("dbo.ItemOwners", "NationalityId", c => c.Int());
            RenameColumn(table: "dbo.ItemOwners", name: "NationalityId", newName: "Nationality_Id");
            CreateIndex("dbo.ItemOwners", "Nationality_Id");
            AddForeignKey("dbo.ItemOwners", "Nationality_Id", "dbo.Countries", "Id");
        }
    }
}

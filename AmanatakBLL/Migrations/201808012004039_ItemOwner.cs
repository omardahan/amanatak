namespace AmanatakBLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemOwner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentificationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        DateOfBirth = c.DateTime(),
                        Gender = c.Boolean(),
                        IdentificationID = c.Int(),
                        IdentificationNo = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        EmailConfirm = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                        Nationality_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentificationTypes", t => t.IdentificationID)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.Nationality_Id)
                .Index(t => t.ItemId)
                .Index(t => t.IdentificationID)
                .Index(t => t.Nationality_Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(),
                        UserCreated = c.String(),
                        DateModified = c.DateTime(),
                        UserModified = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemOwners", "Nationality_Id", "dbo.Countries");
            DropForeignKey("dbo.ItemOwners", "ItemId", "dbo.Items");
            DropForeignKey("dbo.ItemOwners", "IdentificationID", "dbo.IdentificationTypes");
            DropIndex("dbo.ItemOwners", new[] { "Nationality_Id" });
            DropIndex("dbo.ItemOwners", new[] { "IdentificationID" });
            DropIndex("dbo.ItemOwners", new[] { "ItemId" });
            DropTable("dbo.Countries");
            DropTable("dbo.ItemOwners");
            DropTable("dbo.IdentificationTypes");
        }
    }
}

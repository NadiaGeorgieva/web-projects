namespace Vechicles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Brand = c.String(),
                        Color = c.String(),
                        FullDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        DrivingLicence = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Recievers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerListId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shipments", t => t.OwnerListId, cascadeDelete: true)
                .Index(t => t.OwnerListId);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Package = c.String(),
                        From = c.String(),
                        Destination = c.String(),
                        PriceOfPacket = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Shares",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ToDoListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Shipments", t => t.ToDoListId, cascadeDelete: false)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => t.ToDoListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shares", "UserId", "dbo.Users");
            DropForeignKey("dbo.Shares", "ToDoListId", "dbo.Shipments");
            DropForeignKey("dbo.Recievers", "OwnerListId", "dbo.Shipments");
            DropForeignKey("dbo.Shipments", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Drivers", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Cars", "OwnerId", "dbo.Users");
            DropIndex("dbo.Shares", new[] { "ToDoListId" });
            DropIndex("dbo.Shares", new[] { "UserId" });
            DropIndex("dbo.Shipments", new[] { "OwnerId" });
            DropIndex("dbo.Recievers", new[] { "OwnerListId" });
            DropIndex("dbo.Drivers", new[] { "OwnerId" });
            DropIndex("dbo.Cars", new[] { "OwnerId" });
            DropTable("dbo.Shares");
            DropTable("dbo.Shipments");
            DropTable("dbo.Recievers");
            DropTable("dbo.Drivers");
            DropTable("dbo.Users");
            DropTable("dbo.Cars");
        }
    }
}

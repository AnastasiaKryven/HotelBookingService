namespace Hotel.DBManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        RezultSum = c.Single(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
                        ClientId_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.Clients", t => t.ClientId_ClientId)
                .Index(t => t.ClientId_ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDay = c.String(),
                        NumberPhone = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        DateEntry = c.DateTime(nullable: false),
                        DateExit = c.DateTime(nullable: false),
                        Room_RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Rooms", t => t.Room_RoomId)
                .Index(t => t.Room_RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Price = c.Single(nullable: false),
                        CountOfPeople = c.Int(nullable: false),
                        RoomClass = c.String(),
                        RoomState = c.String(),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        TextOfReview = c.String(),
                        Date = c.DateTime(nullable: false),
                        ClientName_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Clients", t => t.ClientName_ClientId)
                .Index(t => t.ClientName_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ClientName_ClientId", "dbo.Clients");
            DropForeignKey("dbo.Bookings", "Room_RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Bills", "ClientId_ClientId", "dbo.Clients");
            DropIndex("dbo.Reviews", new[] { "ClientName_ClientId" });
            DropIndex("dbo.Bookings", new[] { "Room_RoomId" });
            DropIndex("dbo.Bills", new[] { "ClientId_ClientId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
            DropTable("dbo.Clients");
            DropTable("dbo.Bills");
        }
    }
}

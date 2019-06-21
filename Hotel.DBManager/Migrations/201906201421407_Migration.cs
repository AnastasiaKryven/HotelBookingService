namespace Hotel.DBManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Bookings", new[] { "Room_RoomId" });
            AlterColumn("dbo.Bookings", "Room_RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "Room_RoomId");
            AddForeignKey("dbo.Bookings", "Room_RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Room_RoomId", "dbo.Rooms");
            DropIndex("dbo.Bookings", new[] { "Room_RoomId" });
            AlterColumn("dbo.Bookings", "Room_RoomId", c => c.Int());
            CreateIndex("dbo.Bookings", "Room_RoomId");
            AddForeignKey("dbo.Bookings", "Room_RoomId", "dbo.Rooms", "RoomId");
        }
    }
}

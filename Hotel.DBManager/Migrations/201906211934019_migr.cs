namespace Hotel.DBManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rooms", "RoomClass", c => c.String(nullable: false));
            AlterColumn("dbo.Rooms", "RoomState", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rooms", "RoomState", c => c.String());
            AlterColumn("dbo.Rooms", "RoomClass", c => c.String());
        }
    }
}

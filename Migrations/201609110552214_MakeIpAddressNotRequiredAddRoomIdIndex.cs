namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIpAddressNotRequiredAddRoomIdIndex : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workstations", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Workstations", new[] { "IpAddress" });
            DropIndex("dbo.Workstations", new[] { "MacAddress" });
            DropIndex("dbo.Workstations", new[] { "RoomID" });
            AlterColumn("dbo.Workstations", "IpAddress", c => c.String());
            AlterColumn("dbo.Workstations", "MacAddress", c => c.String());
            AlterColumn("dbo.Workstations", "RoomID", c => c.Int(nullable: true));
            CreateIndex("dbo.Workstations", "RoomID");
            AddForeignKey("dbo.Workstations", "RoomID", "dbo.Rooms", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workstations", "RoomID", "dbo.Rooms");
            DropIndex("dbo.Workstations", new[] { "RoomID" });
            AlterColumn("dbo.Workstations", "RoomID", c => c.Int());
            AlterColumn("dbo.Workstations", "MacAddress", c => c.String(maxLength: 450, unicode: false));
            AlterColumn("dbo.Workstations", "IpAddress", c => c.String(nullable: false, maxLength: 100, unicode: false));
            CreateIndex("dbo.Workstations", "RoomID");
            CreateIndex("dbo.Workstations", "MacAddress");
            CreateIndex("dbo.Workstations", "IpAddress");
            AddForeignKey("dbo.Workstations", "RoomID", "dbo.Rooms", "RoomId");
        }
    }
}

namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkgroupVirtualRoom : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Workgroups", "RoomId");
            AddForeignKey("dbo.Workgroups", "RoomId", "dbo.Rooms", "RoomId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workgroups", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Workgroups", new[] { "RoomId" });
        }
    }
}

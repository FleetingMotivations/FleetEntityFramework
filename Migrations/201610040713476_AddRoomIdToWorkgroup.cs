namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoomIdToWorkgroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workgroups", "RoomId", c => c.Int(defaultValue: null));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workgroups", "RoomId");
        }
    }
}

namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkstationPositionDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workstations", "TopXRoomOffset", c => c.Single(nullable: false));
            AddColumn("dbo.Workstations", "TopYRoomOffset", c => c.Single(nullable: false));
            AddColumn("dbo.Workstations", "IsFacilitator", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.Workstations", "Colour", c => c.String(defaultValue: "#000000"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Workstations", "Colour");
            DropColumn("dbo.Workstations", "IsFacilitator");
            DropColumn("dbo.Workstations", "TopYRoomOffset");
            DropColumn("dbo.Workstations", "TopXRoomOffset");
        }
    }
}

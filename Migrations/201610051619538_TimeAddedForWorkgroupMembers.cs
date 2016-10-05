namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeAddedForWorkgroupMembers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkgroupWorkstations", "TimeAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkgroupWorkstations", "TimeAdded");
        }
    }
}

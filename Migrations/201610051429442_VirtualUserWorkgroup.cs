namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VirtualUserWorkgroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workgroups", "CommisionedBy_UserId", "dbo.Users");
            DropIndex("dbo.Workgroups", new[] { "CommisionedBy_UserId" });
            RenameColumn(table: "dbo.Workgroups", name: "CommisionedBy_UserId", newName: "UserId");
            AlterColumn("dbo.Workstations", "LastSeen", c => c.DateTime(nullable: true));
            AlterColumn("dbo.Workgroups", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workgroups", "UserId");
            AddForeignKey("dbo.Workgroups", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
            DropColumn("dbo.Workgroups", "CommisionedById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workgroups", "CommisionedById", c => c.Int(nullable: false));
            DropForeignKey("dbo.Workgroups", "UserId", "dbo.Users");
            DropIndex("dbo.Workgroups", new[] { "UserId" });
            AlterColumn("dbo.Workgroups", "UserId", c => c.Int());
            AlterColumn("dbo.Workstations", "LastSeen", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Workgroups", name: "UserId", newName: "CommisionedBy_UserId");
            CreateIndex("dbo.Workgroups", "CommisionedBy_UserId");
            AddForeignKey("dbo.Workgroups", "CommisionedBy_UserId", "dbo.Users", "UserId");
        }
    }
}

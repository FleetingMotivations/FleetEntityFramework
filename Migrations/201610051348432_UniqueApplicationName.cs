namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueApplicationName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applications", "ApplicationName", c => c.String(nullable: false, maxLength: 100, unicode: false));
            CreateIndex("dbo.Applications", "ApplicationName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Applications", new[] { "ApplicationName" });
            AlterColumn("dbo.Applications", "ApplicationName", c => c.String(nullable: false));
        }
    }
}

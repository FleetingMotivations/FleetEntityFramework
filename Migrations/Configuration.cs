using System.Collections.Generic;
using FleetEntityFramework.Models;

namespace FleetEntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FleetEntityFramework.DAL.FleetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FleetEntityFramework.DAL.FleetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Applications.Add(new Application
            {
                ApplicationName = "FileSharer"
            });
            var campuses = new List<Campus>
            {
                new Campus { CampusIdentifer = "Callaghan"},
                new Campus { CampusIdentifer = "Ourimbah"}
            };
            context.Campuses.AddOrUpdate(c => c.CampusIdentifer, campuses[0], campuses[1]);
            context.SaveChanges();

            context.Buildings.Add(new Building
            {
                BuildingIdentifier = "Engineering Science",
                CampusId = campuses[0].CampusId
            });
            context.SaveChanges();

            context.Rooms.Add(new Room
            {
                RoomIdentifier = "ES205",
                BuildingId = context.Buildings.First(b => b.BuildingIdentifier == "Engineering Science").BuildingId
            });
        }
    }
}

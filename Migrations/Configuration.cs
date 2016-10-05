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

            context.Applications.AddOrUpdate(a => a.ApplicationName, new Application
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

            var users = new List<User>
            {
                new User
                {
                    Identifer = "c3163181",
                    FirstName = "Tristan",
                    LastName = "Newmann",
                    Role = UserRole.Facilitator
                },
                new User
                {
                    Identifer = "c3138738",
                    FirstName = "Alistair",
                    LastName = "Woodock",
                    Role = UserRole.Facilitator
                }
            };

            context.Users.AddOrUpdate(u => u.Identifer, users.ToArray());
            context.SaveChanges();

            context.Buildings.AddOrUpdate(b => b.BuildingIdentifier, new Building
            {
                BuildingIdentifier = "Engineering Science",
                CampusId = campuses[0].CampusId
            });
            context.SaveChanges();

            context.Rooms.AddOrUpdate(r => r.RoomIdentifier, new Room
            {
                RoomIdentifier = "ES205",
                BuildingId = context.Buildings.First(b => b.BuildingIdentifier == "Engineering Science").BuildingId
            });

            context.SaveChanges();

            context.Workgroups.AddOrUpdate(new Workgroup
            {
                Started = DateTime.Now.AddHours(-2),
                Expires = DateTime.Now.AddHours(-1),
                UserId = context.Users.First().UserId,
                RoomId = context.Rooms.First().RoomId,
                AllowedApplications = context.Applications.ToList(),
            });

            context.Workstations.AddOrUpdate(w => w.WorkstationIdentifier, new List<Workstation>
            {
                 new Workstation
                {
                    WorkstationIdentifier = "test1",
                    LastSeen = DateTime.Now,
                    FriendlyName = "test1",
                    TopXRoomOffset = 25,
                    TopYRoomOffset = 50,
                    RoomId = context.Rooms.First().RoomId
                },
                 new Workstation
                 {
                    WorkstationIdentifier = "test2",
                    LastSeen = DateTime.Now.AddHours(-1),
                    FriendlyName = "test2",
                    TopXRoomOffset = 75,
                    TopYRoomOffset = 50,
                    RoomId = context.Rooms.First().RoomId
                 }
            }.ToArray());

            context.SaveChanges();

            context.WorkgroupMembers.AddOrUpdate(new List<WorkgroupWorkstation>
            {
               new WorkgroupWorkstation
               {
                   WorkgroupId = context.Workgroups.First().WorkgroupId,
                   WorkstationId = context.Workstations.First().WorkstationId,
                   SharingEnabled = true,
                   TimeRemoved = null
               },
               new WorkgroupWorkstation
               {
                   WorkgroupId = context.Workgroups.First().WorkgroupId,
                   WorkstationId = context.Workstations.First(w => w.WorkstationIdentifier == "test2").WorkstationId,
                   SharingEnabled = false,
                   TimeRemoved = null
               }
            }.ToArray());

            context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithSociety.Data;

namespace ZenithSociety.Models
{
    public class DummyData
    {
        public static async void Initialize(ApplicationDbContext db)
        {
            string dummyId = "sdgfhgjh";

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db), null, null, null, null, null);

            if(!db.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                await roleManager.CreateAsync(role);
            }

            if (!db.Roles.Any(r => r.Name == "Member"))
            {
                var role = new IdentityRole { Name = "Member" };
                await roleManager.CreateAsync(role);
            }

            string password = "AQAAAAEAACcQAAAAEPFOthX8PAbjhYSJOhjgiHHrrKI2+o/MlC7dNQTjGCQieEXHi9Za76Mkp6EXZ+gl5A==";
            //var passwordHash = new PasswordHasher<ApplicationUser>();
         
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store,null,null,null,null,null,null,null,null);

            if (!db.Users.Any(u => u.UserName == "a"))
            {
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a", PasswordHash = password};
                var result = await manager.CreateAsync(user);
                //passwordHash.HashPassword(user, "P@$$w0rd");

                if (result.Succeeded)
                {
                    dummyId = user.Id;
                    await manager.AddToRoleAsync(user, "Admin");
                }
            }

            if (!db.Users.Any(u => u.UserName == "m"))
            {
                var user1 = new ApplicationUser { UserName = "m", Email = "m@m.c", PasswordHash = password };
                var result = await manager.CreateAsync(user1);
                //passwordHash.HashPassword(user1, "P@$$w0rd");

                if (result.Succeeded)
                {
                   await manager.AddToRoleAsync(user1, "Member");
                }
            }


            if (!db.Activities.Any())
            {
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Lunch",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2016, 10, 13, 6, 10, 0)
                });
                db.SaveChanges();
            }

            if (!db.Events.Any())
            {
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/09/27 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/09/27 10:30 am"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/09/28 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/09/28 10:30 am"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/09/30 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/09/30 7:15 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/09/30 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/09/30 8:00 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/01 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/01 10:30 am"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/01 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/01 12:30 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/01 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/01 1:30 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/02 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/02 8:30 am"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/02 10:30 am"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/02 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/02 10:30 am"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/02 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/10/02 12:30 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/02 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/10/02 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/10/02 6:00 pm"),
                    Id = dummyId,
                    ApplicationUser = db.Users.First(b => b.UserName == "a"),
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/09/10"),
                    IsActive = true
                });
                db.SaveChanges();
            }
        }
    }
}

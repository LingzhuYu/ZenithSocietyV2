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
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Lunch",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.Activities.Add(new Activity
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2016, 11, 23, 6, 10, 0)
                });
                db.SaveChanges();
            }

            if (!db.Events.Any())
            {
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/23 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/23 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/23 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/23 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/24 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/11/24 7:15 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/25 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/25 8:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/26 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/26 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/26 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/26 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/26 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/26 1:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/27 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/27 8:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/27 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/27 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/27 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/27 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/28 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/28 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/28 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/28 1:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/28 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/11/28 6:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/29 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/29 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/29 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/11/29 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/11/30 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/11/30 7:15 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/01 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/01 8:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/01 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/01 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/01 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/01 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/02 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/02 1:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/02 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/02 8:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/03 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/03 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/03 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/03 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/03 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/03 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/04 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/04 1:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/05 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/05 6:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/06 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/06 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/07 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/07 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/08 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/12/08 7:15 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/08 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/08 8:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/09 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/09 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/09 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/09 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/09 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/09 1:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/10 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/10 8:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/11 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/11 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/11 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/11 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/11 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/11 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/12 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/12 1:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/12 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/12 6:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/13 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/13 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Senior's Golf Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/13 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/13 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Leadership General Assembly Meeting"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/14 5:30 pm"),
                    EndDate = Convert.ToDateTime("2016/12/14 7:15 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth Bowling Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/15 7:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/15 8:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Young ladies cooking lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/16 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/16 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth craft lessons"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/16 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/16 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Youth choir practice"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/17 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/17 1:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/17 7:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/17 8:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Pancake Breakfast"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/18 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/18 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Lessons for the youth"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/18 8:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/18 10:30 am"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Swimming Exercise for parents"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/18 10:30 am"),
                    EndDate = Convert.ToDateTime("2016/12/18 12:30 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Bingo Tournament"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/19 12:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/19 1:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "BBQ Lunch"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.Events.Add(new Event
                {
                    StartDate = Convert.ToDateTime("2016/12/20 1:00 pm"),
                    EndDate = Convert.ToDateTime("2016/12/20 6:00 pm"),
                    UserId = dummyId,
                    Activity = db.Activities.First(a => a.ActivityDescription == "Garage Sale"),
                    CreationDate = Convert.ToDateTime("2016/11/10"),
                    IsActive = true
                });
                db.SaveChanges();
            }
        }
    }
}

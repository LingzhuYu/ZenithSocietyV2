using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithSociety.Data;

namespace ZenithSociety.Models
{
    public class Data
    {
        public static void Initialize(ApplicationDbContext db)
        {
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
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tp7.Entities;
using Tp7.Services;
using Xamarin.Forms;

namespace Tp7.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            if (this.Database.EnsureCreated())
            {
                User user = new User() { Login = "test", Password = "password" };
                var tweets = new List<Tweet>()
                {
                    new Tweet(){User = user, Data ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Quisque auctor orci a orci posuere, quis sollicitudin urna rutrum. Phasellus pulvinar, lacus sit amet consequat pretium, elit diam faucibus nisl, quis ornare justo risus sit amet dolor. Nam sed massa vitae", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="maximus arcu lectus at lectus", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce ipsum nisl, accumsan ac diam sed, scelerisque tempus sapien.", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Praesent eu", CreatedAt = DateTime.Now}
                };

                this.Tweets.AddRange(tweets);
                this.SaveChanges();
            }
            this.Database.Migrate();
        }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("MyDb.db3");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}

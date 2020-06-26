using ENI_Xamarin_30032020.Entities;
using ENI_Xamarin_30032020.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENI_Xamarin_30032020.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            if (this.Database.EnsureCreated())
            {
                User user = new User() { Login = "test", Password = "password", Pseudo = "antoine" };
                var tweets = new List<Tweet>()
                {
                    new Tweet() { Identifier = user.Pseudo, User = user, CreationDate = DateTime.Now, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam." },
                    new Tweet() { Identifier = user.Pseudo, User = user, CreationDate = DateTime.Now, Content = "Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur"},
                    new Tweet() { Identifier = user.Pseudo, User = user, CreationDate = DateTime.Now, Content = "Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?"},
                    new Tweet() { Identifier = user.Pseudo, User = user, CreationDate = DateTime.Now, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
                    new Tweet() { Identifier = user.Pseudo, User = user, CreationDate = DateTime.Now, Content = "Non numquam eius modi tempora incidunt ut labore et."},
                    new Tweet() { Identifier = user.Pseudo, User = user, CreationDate = DateTime.Now, Content = "Sed ut perspiciatis unde omnis iste natus error."}
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany<Tweet>().WithOne(x => x.User);
            modelBuilder.Entity<Tweet>().HasOne(x => x.User).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}

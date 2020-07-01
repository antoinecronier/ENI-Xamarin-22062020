using System;
using System.Collections.Generic;
using Tp7Correction.Configurations;
using Tp7Correction.Database;
using Tp7Correction.Entities;
using Tp7Correction.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tp7Correction
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //using (var db = new AppDbContext())
            //{
            //    User user1 = new User() { Login = "test", Password = "password" };
            //    User user2 = new User() { Login = "test1", Password = "password1" };
            //    User user3 = new User() { Login = "test2", Password = "password2" };
            //    var tweets = new List<Tweet>()
            //    {
            //        new Tweet(){User = user1, Data ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ", CreatedAt = DateTime.Now},
            //        new Tweet(){User = user1, Data ="Quisque auctor orci a orci posuere, quis sollicitudin urna rutrum. Phasellus pulvinar, lacus sit amet consequat pretium, elit diam faucibus nisl, quis ornare justo risus sit amet dolor. Nam sed massa vitae", CreatedAt = DateTime.Now},
            //        new Tweet(){User = user1, Data ="maximus arcu lectus at lectus", CreatedAt = DateTime.Now},
            //        new Tweet(){User = user1, Data ="Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce ipsum nisl, accumsan ac diam sed, scelerisque tempus sapien.", CreatedAt = DateTime.Now},
            //        new Tweet(){User = user1, Data ="Praesent eu", CreatedAt = DateTime.Now},
            //        new Tweet(){User = user2, Data ="Praesent eu user2", CreatedAt = DateTime.Now.AddDays(-10)},
            //        new Tweet(){User = user2, Data ="Praesent eu user2 user2", CreatedAt = DateTime.Now.AddDays(-40)},
            //        new Tweet(){User = user3, Data ="Praesent eu user3 user3", CreatedAt = DateTime.Now.AddDays(-5)},
            //        new Tweet(){User = user3, Data ="Praesent eu user3", CreatedAt = DateTime.Now.AddDays(-10)},
            //        new Tweet(){User = user3, Data ="Praesent eu user3 user3 user3", CreatedAt = DateTime.Now.AddDays(-30)},
            //    };

            //    db.Tweets.AddRange(tweets);
            //    db.SaveChanges();
            //}

            var firstPage = new NavigationPage(new MainPage());
            NavigationService.Instance.Initialize(firstPage);

            MainPage = firstPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

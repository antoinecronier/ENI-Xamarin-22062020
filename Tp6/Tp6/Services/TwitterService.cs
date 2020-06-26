using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tp6.Entities;

namespace Tp6.Services
{
    public class TwitterService : ITwitterService
    {
        public List<Tweet> Tweets
        {
            get
            {
                User user = new User() { Login = "test", Password = "password"};
                return new List<Tweet>()
                {
                    new Tweet(){User = user, Data ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque ", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Quisque auctor orci a orci posuere, quis sollicitudin urna rutrum. Phasellus pulvinar, lacus sit amet consequat pretium, elit diam faucibus nisl, quis ornare justo risus sit amet dolor. Nam sed massa vitae", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="maximus arcu lectus at lectus", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce ipsum nisl, accumsan ac diam sed, scelerisque tempus sapien.", CreatedAt = DateTime.Now},
                    new Tweet(){User = user, Data ="Praesent eu", CreatedAt = DateTime.Now}
                };
            }
        }

        public Boolean Authenticate(User user)
        {
            return Tweets.Select(x => x.User).Any(x => x.Login == user.Login && x.Password == user.Password);
        }
    }
}

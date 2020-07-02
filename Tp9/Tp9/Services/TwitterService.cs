using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tp9.Entities;

namespace Tp9.Services
{
    public class TwitterService : ITwitterService
    {
        private User user;

        public List<Tweet> Tweets
        {
            get
            {
                List<Tweet> result = new List<Tweet>();
                //using (var db = new AppDbContext())
                //{
                //    result = db.Tweets.Include(x => x.User).ToList();
                //}

                return result;
            }
        }

        public User ConnectedUser { get => this.user; set => this.user = value; }

        public TwitterService()
        {
            this.user = new User();
        }

        public Boolean Authenticate(User user)
        {
            Boolean result = false;
            //using (var db = new AppDbContext())
            //{
            //    user = db.Users.FirstOrDefault(x => x.Login.Equals(user.Login) && x.Password.Equals(user.Password));
            //}

            if (user != null)
            {
                result = true;
            }

            return result;
        }
    }
}

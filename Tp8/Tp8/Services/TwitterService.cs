using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tp8.Database;
using Tp8.Entities;

namespace Tp8.Services
{
    public class TwitterService : ITwitterService
    {
        public List<Tweet> Tweets
        {
            get
            {
                List<Tweet> result = new List<Tweet>();
                using (var db = new AppDbContext())
                {
                    result = db.Tweets.Include(x => x.User).ToList();
                }

                return result;
            }
        }

        public Boolean Authenticate(User user)
        {
            return Tweets.Select(x => x.User).Any(x => x.Login == user.Login && x.Password == user.Password);
        }
    }
}

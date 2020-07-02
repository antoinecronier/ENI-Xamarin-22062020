using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tp9.Entities;

namespace Tp9.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> GetTweets();
        List<Tweet> GetTweets(String username, DateTime? dateTime);
        User ConnectedUser { get; set; }
    }
}

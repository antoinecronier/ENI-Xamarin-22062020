using System;
using System.Collections.Generic;
using System.Text;
using Tp8.Entities;

namespace Tp8.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> Tweets { get; }
        User ConnectedUser { get; set; }
    }
}

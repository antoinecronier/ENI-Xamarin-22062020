using System;
using System.Collections.Generic;
using System.Text;
using Tp5.Entities;

namespace Tp5.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> Tweets { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Tp6.Entities;

namespace Tp6.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> Tweets { get; }
    }
}

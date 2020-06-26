using ENI_Xamarin_30032020.Data;
using ENI_Xamarin_30032020.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENI_Xamarin_30032020.Services
{
    public class TwitterServiceImpl : ITwitterService
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

        public String Authenticate(User user)
        {
            bool haveError = false;
            StringBuilder stringBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(user.Login) || user.Login.Length < 3)
            {
                stringBuilder.Append("L'identifiant ne peut pas être null et doit posséder au moins 3 caractères.");
                haveError = true;
            }

            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
            {
                if (haveError)
                {
                    stringBuilder.Append("\n");
                }
                haveError = true;
                stringBuilder.Append("Le mot de passe ne peut pas être null et doit posséder au moins 6 caractères.");
            }

            using (var db = new AppDbContext())
            {
                if (!db.Users.Any(x => x.Login == user.Login && x.Password == user.Password))
                {
                    if (haveError)
                    {
                        stringBuilder.Append("\n");
                    }
                    haveError = true;
                    stringBuilder.Append("L'utilisateur n'existe pas.");
                }
            }

            return stringBuilder.ToString();
        }
    }
}

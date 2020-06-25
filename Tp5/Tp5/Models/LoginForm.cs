using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Tp5.Entities;
using Tp5.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Tp5.Models
{
    public class LoginForm
    {
        private readonly ITwitterService twitterService;
        private readonly Entry login;
        private readonly Entry password;
        private readonly Xamarin.Forms.Switch isRemind;
        private readonly VisibilitySwitch visibilitySwitch;
        private readonly ErrorForm error;

        private User user;

        public LoginForm(Entry login, Entry password, Xamarin.Forms.Switch isRemind, View loginForm, View tweetForm, Label errorLabel, Button button)
        {
            this.twitterService = new TwitterService();

            this.login = login;
            this.password = password;
            this.isRemind = isRemind;
            this.visibilitySwitch = new VisibilitySwitch(loginForm, tweetForm);
            this.error = new ErrorForm(errorLabel);
            button.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("btn clicked");

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (this.IsValid())
                {
                    if (twitterService.Authenticate(this.user))
                    {
                        this.error.Hide();
                        this.visibilitySwitch.Switch();
                    }
                    else
                    {
                        this.error.Error = "Utilisateur non trouvé";
                        this.error.Display();
                    }
                }
                else
                {
                    this.error.Display();
                }
            }
            else
            {
                this.error.Error = "Aucune connexion internet";
                this.error.Display();
            }
        }

        public Boolean IsValid()
        {
            Boolean result = true;

            User user = new User();
            user.Login = login.Text;
            user.Password = password.Text;
            Boolean isRemind = this.isRemind.IsToggled;

            bool haveError = false;
            StringBuilder stringBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(user.Login) || user.Login.Length < 3)
            {
                haveError = true;
                stringBuilder.Append("L'identifiant ne peut pas être null et doit posséder au moins 3 caractères.");
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

            if (haveError)
            {
                this.error.Error = stringBuilder.ToString();
            }

            result = !haveError;
            this.user = user;

            return result;
        }
    }
}

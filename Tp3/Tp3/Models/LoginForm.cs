using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Tp3.Models
{
    public class LoginForm
    {
        public Entry Login { get; }
        public Entry Password { get; }
        public Xamarin.Forms.Switch IsRemind { get; }
        public VisibilitySwitch VisibilitySwitch { get; }
        public ErrorForm Error { get; }

        public LoginForm(Entry login, Entry password, Xamarin.Forms.Switch isRemind, View loginForm, View tweetForm, Label errorLabel, Button button)
        {
            this.Login = login;
            this.Password = password;
            this.IsRemind = isRemind;
            this.VisibilitySwitch = new VisibilitySwitch(loginForm, tweetForm);
            this.Error = new ErrorForm(errorLabel);
            button.Clicked += Button_Clicked;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("btn clicked");
            if (this.IsValid())
            {
                this.Error.Hide();
                this.VisibilitySwitch.Switch();
            }
            else
            {
                this.Error.Display();
            }
        }

        public Boolean IsValid()
        {
            Boolean result = true;

            String login = this.Login.Text;
            String password = this.Password.Text;
            Boolean isRemind = this.IsRemind.IsToggled;

            bool haveError = false;
            StringBuilder stringBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(login) || login.Length < 3)
            {
                haveError = true;
                stringBuilder.Append("L'identifiant ne peut pas être null et doit posséder au moins 3 caractères.");
            }

            if (String.IsNullOrEmpty(password) || password.Length < 6)
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
                this.Error.Error = stringBuilder.ToString();
            }

            result = !haveError;

            return result;
        }
    }
}

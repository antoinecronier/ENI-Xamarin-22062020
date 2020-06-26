using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Tp7.Entities;
using Tp7.Services;
using Tp7.Models;

namespace Tp7
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            new LoginForm(this.login, this.password, this.isRemind, this.errorLabel, this.btnConnexion, this.Navigation);
        }

        protected override void OnAppearing()
        {
            this.login.Text = "";
            this.password.Text = "";
            this.isRemind.IsToggled = false;
            base.OnAppearing();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp4.Models;
using Xamarin.Forms;

namespace Tp4
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            new LoginForm(this.login, this.password, this.isRemind, this.loginForm, this.tweetForm, this.errorLabel, this.connection);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Tp9.Entities;
using Tp9.Services;
using Tp9.Models;
using GalaSoft.MvvmLight.Messaging;
using Tp9.ViewModel;

namespace Tp9.Pages
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Messenger.Default.Send<MessageBase, MainPageViewModel>(new MessageBase());
            base.OnAppearing();
        }
    }
}

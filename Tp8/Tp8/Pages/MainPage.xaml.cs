using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Tp8.Entities;
using Tp8.Services;
using Tp8.Models;
using GalaSoft.MvvmLight.Messaging;
using Tp8.ViewModel;

namespace Tp8.Pages
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

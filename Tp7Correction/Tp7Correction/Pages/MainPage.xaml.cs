using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Tp7Correction.Entities;
using Tp7Correction.Services;
using Tp7Correction.Models;
using GalaSoft.MvvmLight.Messaging;
using Tp7Correction.ViewModel;

namespace Tp7Correction.Pages
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

using ENI_Xamarin_30032020.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENI_Xamarin_30032020.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetCreateView : ContentView
    {
        public TweetCreateView()
        {
            InitializeComponent();
        }
        protected override void OnParentSet()
        {
            Messenger.Default.Send<GenericMessage<int>, TweetCreateViewViewModel>(new GenericMessage<int>(1));
            base.OnParentSet();
        }
    }
}
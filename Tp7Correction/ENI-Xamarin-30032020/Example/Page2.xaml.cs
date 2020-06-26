using ENI_Xamarin_30032020.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENI_Xamarin_30032020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private Page2ViewModel vm;

        public Button Btn
        {
            get { return this.btn; }
        }

        public Page2()
        {
            InitializeComponent();
            BindingContext = new Page2ViewModel(this);
        }
    }
}
using ENI_Xamarin_30032020.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENI_Xamarin_30032020.Example
{
    public class Page2ViewModel
    {
        public User User { get; set; }

        private Page2 page2;

        public String MyProperty { get; set; } = "Bonjour";

        public Page2ViewModel(Page2 page2)
        {
            this.User = new User() { Login = "coucou", Password = "Password" };
            this.page2 = page2;
            this.page2.Btn.Clicked += Btn_Clicked;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(this.User.Password);
            this.UpdatePassword();
        }

        public void UpdatePassword()
        {
            this.User.Password = "CodeBehindPwd";
        }
    }
}

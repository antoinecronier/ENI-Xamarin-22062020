using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tp7Correction.Models
{
    public class ErrorForm
    {
        private readonly Label errorLabel;
        public String Error { get; set; }

        public ErrorForm(Label errorLabel)
        {
            this.errorLabel = errorLabel;
            this.SetupErrorLabel();
        }

        private void SetupErrorLabel()
        {
            this.errorLabel.BackgroundColor = Color.Red;
            this.errorLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Hide();
        }

        public void Display()
        {
            this.errorLabel.Text = this.Error;
            this.errorLabel.IsVisible = true;
        }

        public void Hide()
        {
            this.errorLabel.IsVisible = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tp8.Entities
{
    public class BaseNotyfied : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}

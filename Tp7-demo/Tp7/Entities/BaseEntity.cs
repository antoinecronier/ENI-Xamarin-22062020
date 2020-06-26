using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tp7.Entities
{
    public class BaseEntity : INotifyPropertyChanged
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

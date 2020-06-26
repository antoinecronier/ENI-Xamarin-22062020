using ENI_Xamarin_30032020.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class SearchViewViewModel : ViewModelBase, INotifyPropertyChanged
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

        private String pickerSelection;
        private String pickerSelectionValue;
        private ObservableCollection<SearchListItem> selectedSearch;

        public String PickerSelection
        {
            get { return pickerSelection; }
            set
            {
                pickerSelection = value;
                OnPropertyChanged("PickerSelection");
            }
        }

        public String PickerSelectionValue
        {
            get { return pickerSelectionValue; }
            set
            {
                pickerSelectionValue = value;
                OnPropertyChanged("PickerSelectionValue");
            }
        }

        public ObservableCollection<SearchListItem> SelectedSearch
        {
            get { return selectedSearch; }
            set { selectedSearch = value; }
        }

        public List<String> Choices
        {
            get
            {
                return new List<String>()
                {
                    SearchChoices.Date.ToString(),
                    SearchChoices.Identifiant.ToString(),
                    SearchChoices.NomUtilisateur.ToString()
                };
            }
        }

        private Boolean searchVisibility;

        public Boolean SearchVisibility
        {
            get { return searchVisibility; }
            set { searchVisibility = value; }
        }

        public RelayCommand AddSearch
        {
            get 
            { 
                return new RelayCommand(()=>
                {
                    if (!String.IsNullOrEmpty(PickerSelection) && !String.IsNullOrEmpty(PickerSelectionValue))
                    {
                        bool validate = true;
                        if (PickerSelection == SearchChoices.Date.ToString())
                        {
                            if (!DateTime.TryParse(PickerSelectionValue, out _))
                            {
                                validate = false;
                            }
                        }

                        if (validate)
                        {
                            this.selectedSearch.Add(new SearchListItem(this.selectedSearch) { Choice = PickerSelection, Value = PickerSelectionValue });
                            PickerSelection = "";
                            PickerSelectionValue = "";
                        }
                    }
                }); 
            }
        }

        public RelayCommand Search
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var items = this.SelectedSearch.ToList();
                    Messenger.Default.Send<GenericMessage<List<SearchListItem>>, TweetsViewViewModel > (new GenericMessage<List<SearchListItem>>(items));
                    Messenger.Default.Send<GenericMessage<int>, TweetsPageViewModel>(new GenericMessage<int>(0));
                    this.SearchVisibility = false;
                });
            }
        }

        public SearchViewViewModel()
        {
            this.SearchVisibility = false;
            this.selectedSearch = new ObservableCollection<SearchListItem>(); 
            Messenger.Default.Register<GenericMessage<int>>(this, NotifyMe);
        }

        private void NotifyMe(GenericMessage<int> value)
        {
            switch (value.Content)
            {
                case 0:
                    this.SearchVisibility = false;
                    break;
                case 1:
                    this.SearchVisibility = true;
                    break;
                default:
                    break;
            }
        }
    }
}

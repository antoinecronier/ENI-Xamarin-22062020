using System;
using System.Collections.Generic;
using System.Text;
using Tp7Correction.Entities;

namespace Tp7Correction.Models
{
    public class TweetSearch : BaseNotyfied
    {
        private DateTime searchDate;

        public DateTime SearchDate
        {
            get { return searchDate; }
            set 
            { 
                searchDate = value;
                this.OnPropertyChanged("SearchDate");
            }
        }

        private String username;

        public String Username
        {
            get { return username; }
            set 
            { 
                username = value;
                this.OnPropertyChanged("Username");
            }
        }

        public TweetSearch()
        {

        }
    }
}

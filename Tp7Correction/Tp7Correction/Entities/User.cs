using System;
using System.Collections.Generic;
using System.Text;

namespace Tp7Correction.Entities
{
    public class User : BaseNotyfied, BaseDbEntity
    {
        private int id;
        private String login;
        private String password;

        public String Login
        {
            get { return login; }
            set 
            { 
                login = value;
                this.OnPropertyChanged("Login");
            }
        }

        public String Password
        {
            get { return password; }
            set 
            { 
                password = value;
                this.OnPropertyChanged("Password");
            }
        }

        public int Id { get => this.id; set => this.id = value; }
    }
}

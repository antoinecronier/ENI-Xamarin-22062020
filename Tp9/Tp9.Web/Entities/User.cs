using System;
using System.Collections.Generic;
using System.Text;

namespace Tp9.Entities
{
    public class User : BaseDbEntity
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
            }
        }

        public String Password
        {
            get { return password; }
            set 
            { 
                password = value;
            }
        }

        public int Id { get => this.id; set => this.id = value; }
    }
}

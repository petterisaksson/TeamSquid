using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YH_Admin.Model
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string PassWord { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Name { get { return $"{Firstname} {Lastname}"; } }

        public User(int uId, string username, string password, string firstname, string lastname)
        {
            UserId = uId;
            Username = username;
            PassWord = password;
            Firstname = firstname;
            Lastname = lastname;
        }

        public override string ToString()
        {
            return UserId + " " + Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Killer_App.Helpers
{
    public class User
    {
        public int Id { get; }
        public string UserName { get; }
        public string Firstname { get; }
        public string LastName { get; }
        public string Email { get; }

        public User(int id, string userName, string firstname, string lastName, string email)
        {
            Id = id;
            UserName = userName;
            Firstname = firstname;
            LastName = lastName;
            Email = email;
        }
    }
}
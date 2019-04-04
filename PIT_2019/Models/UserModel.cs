using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIT_2019.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Phome { get; set; }
        public UserRights Rights { get; set; }
    }

    public enum UserRights
    {
        Seamstress = 1,
        Administrator = 2
    }
}
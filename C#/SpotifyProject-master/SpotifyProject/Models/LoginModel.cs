using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyProject.Models
{
    public class LoginModel
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool role { get; set; }
    }

    public class AccountDetails
    {
        public string username { get; set; }
    }
}

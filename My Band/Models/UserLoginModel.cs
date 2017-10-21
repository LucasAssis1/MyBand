using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace My_Band.Models
{
    public class UserLoginModel
    {
        public String grant_type { get { return "password"; }}
        public String username { get; set; }
        public String password { get; set; }
        public String client_id { get { return username; } }
        public String client_password { get { return password; } }

    }
}
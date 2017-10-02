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
    public class UserModel
    {
        public Guid ID { get; set; }

        public String Email { get; set; }

        public String Name { get; set; }

        public String Password { get; set; }

        public String State { get; set; }

        public String City { get; set; }

        public String Phone { get; set; }

        public String About { get; set; }

        public byte[] Photo { get; set; }
    }
}
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
using My_Band.Models;
using Newtonsoft.Json;

namespace My_Band
{
    public class UserProfileFragment : Android.Support.V4.App.Fragment
    {

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var token = new TokenModel
            {
                Access_Token = Arguments.GetString("Access_Token"),
                Refresh_Token = Arguments.GetString("Refresh_Token"),
                Expires_In = Arguments.GetString("Expires_In"),
                Token_Type = Arguments.GetString("Token_Type")
            };

            var user = JsonConvert.DeserializeObject<UserModel>(Arguments.GetString("user"));
            // Use this to return your custom view for this Fragment 
            View view = inflater.Inflate(Resource.Layout.UserProfileLayout, container, false);
            Button mBtnEditProfile = view.FindViewById<Button>(Resource.Id.btnAddBand);
            TextView tvUsername = view.FindViewById<TextView>(Resource.Id.tvProfileUsername);
            TextView tvEmail = view.FindViewById<TextView>(Resource.Id.tvProfileEmail);

            tvEmail.Text = user.Email;
            tvUsername.Text = user.Name;

            mBtnEditProfile.Click += mBtnEditProfile_Click;

            return view;
        }

        private void mBtnEditProfile_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.Activity, typeof(Activities.ActivityAddBand));
            this.StartActivity(intent);

        }
    }
}
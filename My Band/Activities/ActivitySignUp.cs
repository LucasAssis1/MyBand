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
using My_Band.Activities;
using Newtonsoft.Json;
using Android.Views.InputMethods;

namespace My_Band
{
    [Activity(Label = "ActivitySignUp")]
    public class ActivitySignUp : Activity
    {

        Button mBtnNext;
        ImageView mBtnRegisterBack;
        LinearLayout mLinearLayout;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Cadastro);

            
            mBtnNext = FindViewById<Button>(Resource.Id.btnNext);
            mBtnNext.Click += mBtnNext_Click;


            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.RegisterLinearLayout);
            mLinearLayout.Click += mLinearLayout_Click;
            mBtnRegisterBack = FindViewById<ImageView>(Resource.Id.ivRegisterBack);
            mBtnRegisterBack.Click += mBtnRegisterBack_Click;

        }

        private void mLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private void mBtnNext_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel()
            {
                Email = FindViewById<EditText>(Resource.Id.etEmail).Text,
                Name = FindViewById<EditText>(Resource.Id.etUserName).Text,
                Password = FindViewById<EditText>(Resource.Id.etConfirmPassword).Text
            };

            Intent intent = new Intent(this, typeof(ActivitySignUpOptional));


            intent.PutExtra("user", JsonConvert.SerializeObject(user));
            this.StartActivity(intent);

        }

        private void mBtnRegisterBack_Click(object sender, EventArgs e)
        {

            base.OnBackPressed();
            /*Intent intent = new Intent(this, typeof(MainActivity));
            this.StartActivity(intent);*/
        }
    }
}
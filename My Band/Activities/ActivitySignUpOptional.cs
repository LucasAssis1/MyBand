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
using System.IO;
using Android.Views.InputMethods;
using My_Band.DataService;

namespace My_Band.Activities
{
    [Activity(Label = "ActivitySignUpOptional")]
    public class ActivitySignUpOptional : Activity
    {
        DataServiceAPI dataService;
        UserModel mUser;
        AutoCompleteTextView mActvGenres;
        EditText mEtState;
        EditText mEtCity;
        EditText mEtPhone;
        EditText mEtAbout;
        Button mBtnSubmit;
        LinearLayout mLinearLayout;
        ImageView mBtnRegisterOptionalBack;
        TextView mTvSkip;

        public ActivitySignUpOptional()
        {
            dataService = new DataServiceAPI();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CadastroOpcional);

            mTvSkip = FindViewById<TextView>(Resource.Id.tvSkip);
            mTvSkip.Click += mTvSkip_Click;

            mBtnSubmit = FindViewById<Button>(Resource.Id.btnRegisterSubmit);
            mActvGenres = FindViewById<AutoCompleteTextView>(Resource.Id.actvGenres);

            mBtnRegisterOptionalBack = FindViewById<ImageView>(Resource.Id.ivRegisterOptionalBack);
            mBtnRegisterOptionalBack.Click += mBtnRegisterOptionalBack_Click;

            Stream seedDataStream = Assets.Open(@"WordList.txt");
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader(seedDataStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            string[] wordlist = lines.ToArray();
            ArrayAdapter dictionaryAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, wordlist);
            mActvGenres.Adapter = dictionaryAdapter;

            mLinearLayout = FindViewById<LinearLayout>(Resource.Id.RegisterLinearLayout);
            mLinearLayout.Click += mLinearLayout_Click;

            mBtnSubmit.Click += mBtnSubmit_Click;

        }

        private void mTvSkip_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ActivityMainView));
            this.StartActivity(intent);
        }

        private void mLinearLayout_Click(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.None);
        }

        private async void mBtnSubmit_Click(object sender, EventArgs e)
        {
 
            mEtState = FindViewById<EditText>(Resource.Id.etState);
            mEtCity = FindViewById<EditText>(Resource.Id.etCity);
            mEtPhone = FindViewById<EditText>(Resource.Id.etPhone);
            mEtAbout = FindViewById<EditText>(Resource.Id.etAbout);

            mUser = new UserModel();

            mUser = JsonConvert.DeserializeObject<UserModel>(Intent.GetStringExtra("user"));
            
            mUser.State = mEtState.Text;
            mUser.City = mEtCity.Text;
            mUser.Phone = mEtPhone.Text;
            mUser.About = mEtAbout.Text;
            


            Intent intent = new Intent(this, typeof(ActivityMainView));

            intent.PutExtra("mUser", JsonConvert.SerializeObject(mUser));

            var result = await dataService.AddUsersAsync(mUser);

            if (result == true)
            {
                this.StartActivity(intent);
            }
            else
            {

            }

        }
        private void mBtnRegisterOptionalBack_Click(object sender, EventArgs e)
        {
            base.OnBackPressed();
            /*Intent intent = new Intent(this, typeof(ActivitySignUp));
            this.StartActivity(intent);*/
        }
    }
}
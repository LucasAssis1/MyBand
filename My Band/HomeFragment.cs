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

namespace My_Band
{
    public class HomeFragment : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            
            // Use this to return your custom view for this Fragment 
            
            View view = inflater.Inflate(Resource.Layout.HomeLayout, container, false);
            RatingBar mRatingBarRank2 = view.FindViewById<RatingBar>(Resource.Id.ratingBarRank2);
            mRatingBarRank2.Rating = 5f;
            return view;
        }
    }
}
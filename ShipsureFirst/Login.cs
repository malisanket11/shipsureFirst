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

namespace ShipsureFirst
{
    [Activity(Label = "login")]
    public class Login : Activity
    {
        Button btnLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loginLayout);
            btnLogin = FindViewById<Button>(Resource.Id.ButtonLogin);

            //fetch intent extra
            btnLogin.Click += (s, e) => {
                Intent i = new Intent(this, typeof(EnterSuite));
                StartActivity(i);
            };

        }
    }
}
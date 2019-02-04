using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace ShipsureFirst
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView txtCopyRight;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Button btnConnect;
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            if (Android.OS.Build.VERSION.SdkInt > BuildVersionCodes.Lollipop)
            {
                StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().PermitAll().Build();
                StrictMode.SetThreadPolicy(policy);
            }

            txtCopyRight = (TextView)FindViewById(Resource.Id.textView2Copyright);
            btnConnect = (Button)FindViewById(Resource.Id.ButtonConnect);
            btnConnect.Click +=(s,e) => {
                Intent i = new Intent(this, typeof(Login));                
                StartActivity(i);
            };
            txtCopyRight.Click += TxtCopyRight_Click;

            

        }

        private void TxtCopyRight_Click(object sender, System.EventArgs e)
        {
            //show Copyrights
        }
    }
}
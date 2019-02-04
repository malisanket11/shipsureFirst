using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Newtonsoft.Json;
using Android.Views;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace ShipsureFirst
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class SuiteDetails: AppCompatActivity
    {
        private Suite suite;
        private ListView listView;
        private TextView nameTextView;
        private TextView typeTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.activity_suite_details);


            suite = JsonConvert.DeserializeObject<Suite>(Intent.GetStringExtra("SuiteObj"));

        

            listView = (ListView)FindViewById(Resource.Id.itemListView);
            ArrayAdapter adapter = new ArrayAdapter(ApplicationContext, Android.Resource.Layout.SimpleListItem1, suite.ItemList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            listView.Adapter = adapter;
            listView.ItemClick += ListView_ItemClick; ;

            nameTextView = (TextView)FindViewById(Resource.Id.nameTextView);
            typeTextView = (TextView)FindViewById(Resource.Id.typeTextView);
            nameTextView.Text = suite.Name;
            typeTextView.Text = suite.Type;



        }


        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this,typeof(Components));
            Item item = suite.ItemList[e.Position];
            intent.PutExtra("item", JsonConvert.SerializeObject(item));
            intent.PutExtra("suite", JsonConvert.SerializeObject(suite));
            StartActivity(intent);
        }
    }
}
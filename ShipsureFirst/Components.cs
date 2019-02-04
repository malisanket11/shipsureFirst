using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ShipsureFirst
{
    [Activity(Label = "Components", Theme = "@style/AppTheme")]
    public class Components : Activity
    {

        private TextView nameCompTextView;
        private TextView typeCompTextView;
        private TextView itemComptextView;
        private ListView listView;
        private Item item;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_components);


            item = JsonConvert.DeserializeObject<Item>(Intent.GetStringExtra("item"));
            Suite suite = JsonConvert.DeserializeObject<Suite>(Intent.GetStringExtra("suite"));



            nameCompTextView = (TextView)FindViewById(Resource.Id.nameCompTextView);
            typeCompTextView = (TextView)FindViewById(Resource.Id.typeCompTextView);
            itemComptextView = (TextView)FindViewById(Resource.Id.itemCompTextView);
            listView = (ListView)FindViewById(Resource.Id.compListView);
            Log.Debug("itemName:", item.Name);
            nameCompTextView.Text = suite.Name;
            typeCompTextView.Text = suite.Type;
            itemComptextView.Text = item.Name;

            ArrayAdapter adapter = new ArrayAdapter(ApplicationContext, Android.Resource.Layout.SimpleListItem1, item.ComponentList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            listView.Adapter = adapter;
            listView.ItemClick += ListView_ItemClick;

            //GridView gridView = (GridView)FindViewById(Resource.Id.gridView1);
            //gridView.Adapter = new GridViewAdapterHandler(item.ComponentList, ApplicationContext);
            //gridView.ItemClick += GridView_ItemClick;

        }

        private void GridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Intent intent = new Intent(this, typeof(DefectDetails));
            //Component component = item.ComponentList[e.Position];
            //intent.PutExtra("component", JsonConvert.SerializeObject(component));
            //intent.PutExtra("item", JsonConvert.SerializeObject(item));
            //StartActivity(intent);
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(DefectDetails));
            Component component = item.ComponentList[e.Position];
            intent.PutExtra("component", JsonConvert.SerializeObject(component));
            intent.PutExtra("item", JsonConvert.SerializeObject(item));
            StartActivity(intent);
        }
    }
}
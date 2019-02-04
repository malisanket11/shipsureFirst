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
using Newtonsoft.Json;

namespace ShipsureFirst
{
    [Activity(Label = "DefectDetails", Theme = "@style/AppTheme")]
    public class DefectDetails : Activity
    {
        private Component component;
        private Item item;
        private Button showOpenButton;
        private Button showCloseButton;
        private Button addDefectButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_defect);

            component = JsonConvert.DeserializeObject<Component>(Intent.GetStringExtra("component"));
            item = JsonConvert.DeserializeObject<Item>(Intent.GetStringExtra("item"));

            showOpenButton = (Button) FindViewById(Resource.Id.showOpenButton);
            showCloseButton = (Button) FindViewById(Resource.Id.showClosedButton);
            addDefectButton = (Button) FindViewById(Resource.Id.addDefectButton);
            addDefectButton.Click += AddDefectButton_Click;

            showOpenButton.Click += ShowOpenButton_Click;
            showCloseButton.Click += ShowCloseButton_Click;

            List<Defect> closedDefects = new List<Defect>();
            for (int i = 0; i < component.DefectList.Count; i++)
            {
                if (component.DefectList[i].IsOpen)
                {
                    closedDefects.Add(component.DefectList[i]);
                }
            }
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            DefectListFragment defectListFragment = DefectListFragment.NewInstance(closedDefects);
            ft.Replace(Resource.Id.container, defectListFragment);
            ft.Commit();


            showOpenButton.Text = "Open:" + closedDefects.Count;
            showCloseButton.Text = "Closed:" + (component.DefectList.Count-closedDefects.Count);



            //listView = (ListView) FindViewById(Resource.Id.defectList);

            //ArrayAdapter adapter = new ArrayAdapter(ApplicationContext, Android.Resource.Layout.SimpleListItem1,component.DefectList );
            //adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            //listView.Adapter = adapter;
            //listView.ItemClick += ListView_ItemClick; ;

            //listView.Adapter = new DefectAdapterHandler(ApplicationContext,component.DefectList);
            //listView.ItemClick += ListView_ItemClick; ;

        }

        private void AddDefectButton_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this,typeof(AddDefectActivity));
            StartActivity(intent);
        }

        private void ShowCloseButton_Click(object sender, EventArgs e)
        {
            List<Defect> closedDefects = new List<Defect>();
            for (int i = 0; i < component.DefectList.Count; i++)
            {
                if (!component.DefectList[i].IsOpen)
                {
                    closedDefects.Add(component.DefectList[i]);
                }
            }
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            DefectListFragment defectListFragment = DefectListFragment.NewInstance(closedDefects);
            ft.Replace(Resource.Id.container, defectListFragment);
            ft.Commit();
        }

        private void ShowOpenButton_Click(object sender, EventArgs e)
        {
            List<Defect> closedDefects = new List<Defect>();
            for (int i = 0; i < component.DefectList.Count; i++)
            {
                if (component.DefectList[i].IsOpen)
                {
                    closedDefects.Add(component.DefectList[i]);
                }
            }
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            DefectListFragment defectListFragment = DefectListFragment.NewInstance(closedDefects);
            ft.Replace(Resource.Id.container, defectListFragment);
            ft.Commit();
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }
    }
}
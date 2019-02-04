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
    [Activity(Label = "Timeline")]
    public class Timeline : Activity
    {
        ImageButton btnDetails, btnImage;
        bool isTimelineDetailLoaded;
        Suite suite;
        Item item;
        Component component;
        Defect defect;

        private FragmentTransaction fragmentTransaction;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.timelineMain);


            suite = new Suite();
            item = new Item();
            component = new Component();
            defect = new Defect();
            suite = JsonConvert.DeserializeObject<Suite>(Intent.GetStringExtra("SuiteObj"));
            item = JsonConvert.DeserializeObject<Item>(Intent.GetStringExtra("ItemObj"));
            component = JsonConvert.DeserializeObject<Component>(Intent.GetStringExtra("ComponentObj"));
            defect = JsonConvert.DeserializeObject<Defect>(Intent.GetStringExtra("DefectObj"));


            btnDetails = (ImageButton)FindViewById(Resource.Id.imageButtonDetails);
            btnImage = (ImageButton)FindViewById(Resource.Id.imageButtonImage);

             fragmentTransaction = FragmentManager.BeginTransaction();
            fragmentTransaction.Replace(Resource.Id.container, TimelineFragment.NewInstance(suite,item,component,defect));
            fragmentTransaction.Commit();
            isTimelineDetailLoaded = true;
            btnDetails.Click += Details_Click;
            btnImage.Click += BtnImage_Click;

        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            if (isTimelineDetailLoaded==true)
            {
                isTimelineDetailLoaded = false;
                fragmentTransaction = FragmentManager.BeginTransaction();
                fragmentTransaction.Replace(Resource.Id.container, DefectImageFragment.NewInstance(defect));
                fragmentTransaction.Commit();
            }
            
        }

        private void Details_Click(object sender, EventArgs e)
        {
            if (isTimelineDetailLoaded==false)
            {
                isTimelineDetailLoaded = true;
                fragmentTransaction = FragmentManager.BeginTransaction();
                fragmentTransaction.Replace(Resource.Id.container, TimelineFragment.NewInstance(suite, item, component, defect));
                fragmentTransaction.Commit();
            }
            
        }
    }
}
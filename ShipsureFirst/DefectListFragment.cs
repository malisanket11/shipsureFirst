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

namespace ShipsureFirst
{
    public class DefectListFragment : Fragment
    {
        private List<Defect> defects;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        public static DefectListFragment NewInstance(List<Defect> defects)
        {
            DefectListFragment defectListFragment = new DefectListFragment();
            defectListFragment.defects = defects;
            return defectListFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.fragment_defect_list, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
            
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ListView listView = view.FindViewById<ListView>(Resource.Id.fDefectListView);
            listView.Adapter = new DefectAdapterHandler(view.Context,defects);
            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(Activity, typeof(Timeline));
            StartActivity(intent);
        }
    }
}
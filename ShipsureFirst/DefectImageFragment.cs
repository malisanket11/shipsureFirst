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
    public class DefectImageFragment : Fragment
    {
        private Defect defect;
        TextView tv;
        public static DefectImageFragment NewInstance(Defect defect)//accept objet
        {
            DefectImageFragment fragmentDefectImage = new DefectImageFragment
            {
                defect = defect
            };
            return fragmentDefectImage;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.DefectImageGrideFrag, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            tv=view.FindViewById<TextView>(Resource.Id.textViewDefectTitle);
            tv.Text=(defect.Id);
        }
    }
}
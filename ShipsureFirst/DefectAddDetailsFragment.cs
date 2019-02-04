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
    public class DefectAddDetailsFragment : Fragment
    {

        public EditText TypeText { get; set; }
        public EditText PriorityText { get; set; }
        public EditText DescriptionText { get; set; }
        public EditText ItemNameText { get; set; }
        public EditText compNameText { get; set; }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }

        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_defect_add, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            TypeText = (EditText) view.FindViewById(Resource.Id.typeText);
            PriorityText = (EditText) view.FindViewById(Resource.Id.priorityText);
            DescriptionText = (EditText) view.FindViewById(Resource.Id.descriptionText);
            ItemNameText = (EditText) view.FindViewById(Resource.Id.itemNameText);
            compNameText = (EditText) view.FindViewById(Resource.Id.compNameText);
        }

        
    }
}
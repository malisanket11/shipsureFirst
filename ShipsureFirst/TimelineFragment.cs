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
    public class TimelineFragment : Fragment
    {
       // private List<Contact> contacts;
        private IOpenImageGridListener listener;

        TextView componentTextview, suiteidTextview, suiteTypeTextview, itemTextview, defectTypeTextview, defectStatusTextview, defectPriorityTextview, descriptionTextview;
        //ImageView ComponentImage;
        Suite suite;
        Item item;
        Component component;
        Defect defect;

        public static TimelineFragment NewInstance(Suite suite, Item item,Component component, Defect defect)//accept objet
        {
            TimelineFragment fragmentTimeline = new TimelineFragment
            {
                suite = suite,
                item = item,
                component = component,
                defect = defect
            };

            return fragmentTimeline;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            if (context is IOpenImageGridListener)
            {
                listener = (IOpenImageGridListener)context;
            }
            else
            {
                Log.Debug("couldnt attach", "");
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
             return inflater.Inflate(Resource.Layout.timelineFrag, container, false);

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            componentTextview = (TextView)view.FindViewById(Resource.Id.textViewComponent);
            suiteidTextview = (TextView)view.FindViewById(Resource.Id.textViewSuiteName);
            suiteTypeTextview = (TextView)view.FindViewById(Resource.Id.textViewSuiteType);
            itemTextview = (TextView)view.FindViewById(Resource.Id.textViewItem);
            defectTypeTextview = (TextView)view.FindViewById(Resource.Id.textViewTypeData);
            defectStatusTextview = (TextView)view.FindViewById(Resource.Id.textViewStatusData);
            defectPriorityTextview = (TextView)view.FindViewById(Resource.Id.textViewPriorityData);
            descriptionTextview = (TextView)view.FindViewById(Resource.Id.textViewDescriptionData);

            
            componentTextview.Text = component.Name;
            suiteidTextview.Text = suite.Name;
            suiteTypeTextview.Text = suite.Type;
            itemTextview.Text = item.Name;
            defectTypeTextview.Text = defect.Type;
            defectStatusTextview.Text = defect.Status;
            defectPriorityTextview.Text = defect.Priority;
            descriptionTextview.Text = defect.Description;
        }

    }
    interface IOpenImageGridListener
    {
        void OpenImageGrid();//send class object
    }
}
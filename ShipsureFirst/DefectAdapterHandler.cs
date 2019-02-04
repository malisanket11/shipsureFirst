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
    class DefectAdapterHandler : BaseAdapter<Defect>
    {
        private Context context;
        private List<Defect> defects;

        public DefectAdapterHandler(Context context, List<Defect> defects):base()
        {
            this.context = context;
            this.defects = defects;

        }

        public override Defect this[int position]
        {
            get { return defects[position]; }
        }

        public override int Count
        {
            get { return defects.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = defects[position];
            View view = convertView;
            if (view == null)
            {
                var inflater = LayoutInflater.FromContext(context);
                view = inflater.Inflate(Resource.Layout.defect_layout, null);
            }
            view.FindViewById<TextView>(Resource.Id.defectIDview).Text = item.Id;
            view.FindViewById<TextView>(Resource.Id.reportText).Text = item.ReportedOn;
            view.FindViewById<TextView>(Resource.Id.faultyText).Text = item.Type;
            view.FindViewById<TextView>(Resource.Id.OverdueText).Text =item.Overdue.ToString();
            view.FindViewById<TextView>(Resource.Id.textView7).Text =item.Critical.ToString();
            
            return view;
        }
    }
    
}
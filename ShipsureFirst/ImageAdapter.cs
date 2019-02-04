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
using Java.Lang;

namespace ShipsureFirst
{
    public class ImageAdapter : BaseAdapter
    {
        Context context;
        public List<ImageView> ImageViews { get; set; }
        public ImageAdapter(Context c,List<ImageView> imageViews)
        {
            context = c;
            ImageViews = imageViews;
        }
        public override int Count
        {
            get
            {
                return ImageViews.Count;
            }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return 0;
        }
        // create a new ImageView for each item referenced by the Adapter   
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ImageView imageView;
            if (convertView == null)
            { // if it's not recycled, initialize some attributes   
                imageView = new ImageView(context);
                imageView.LayoutParameters = new GridView.LayoutParams(150, 150);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }
            imageView =ImageViews[position];
            return imageView;
        }
        
    }
}
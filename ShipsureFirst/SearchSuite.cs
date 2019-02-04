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
    [Activity(Label = "searchSuite")]
    public class SearchSuite : Activity
    {
        AutoCompleteTextView actvSearchSuiteNumber;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.searchSuite);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this,Resource.Array.suiteNumber);
            actvSearchSuiteNumber = (AutoCompleteTextView)FindViewById(Resource.Id.autoCompleteEnterSuite);
            actvSearchSuiteNumber.Adapter = adapter;

        }
    }
}
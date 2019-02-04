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
    [Activity(Label = "EnterSuite")]
    public class EnterSuite : Activity
    {
        AutoCompleteTextView actvSuiteNumber;
        Button btnEnterSuite;
        TextView errorText;
        Suite suite;
        Dictionary<string, Suite> suiteMap;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EnterSuite);
            btnEnterSuite = (Button)FindViewById(Resource.Id.ButtonEnterSuite);
            actvSuiteNumber = (AutoCompleteTextView)FindViewById(Resource.Id.autoCompleteTextViewSuiteNumber);
            errorText = (TextView)FindViewById(Resource.Id.incorrectSuiteNumberWarning);
            ////
            suiteMap = new Dictionary<string, Suite>();
            for (int l = 0; l < 5; l++)
            {
                suite = new Suite
                {
                    Name = "S1234" + l,
                    Type = "Deluxe Suite"
                };
                for (int i = 0; i < 5; i++)
                {
                    Item item = new Item();
                    for (int k = 0; k < 5; k++)
                    {
                        Component component = new Component();

                        for (int j = 0; j < 5; j++)
                        {
                            Defect defect = new Defect();
                            defect.Id = j + "";
                            defect.Critical = false;
                            defect.Overdue = false;
                            defect.ReportedOn = null;
                            defect.Type = "faulty";
                            defect.IsOpen = false;
                            if (j % 2 == 0)
                            {
                                defect.IsOpen = true;
                            }
                            component.DefectList.Add(defect);
                        }
                        component.Name = "Component" + k;
                        item.ComponentList.Add(component);
                    }
                    item.Name = "Item" + i;
                    suite.ItemList.Add(item);
                }
                suiteMap.Add(suite.Name, suite);
            }

            /*try {*/
             /*} catch (Exception ex) { Log.Debug("Tag",ex.Message); }*/

            //List<Suite> suiteList = suiteMap.Values.ToList<Suite>();
            List<string> suiteList = new List<string>();
            foreach (var Suite1 in suiteMap.Values)
            {
                suiteList.Add(Suite1.Name);
            }
            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, suiteList);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);
            actvSuiteNumber.Adapter = adapter;

            ////

            btnEnterSuite.Click += (s, arg) =>
            {
                //string suiteKey = actvSuiteNumber.Text.ToString();
                //*****HardCoded
                string suiteKey = "S12340";
                if (suiteMap.ContainsKey(suiteKey))
                {
                    Log.Debug("Tag Go To timeline ", "in Enter");
                    btnEnterSuite.Click += (sender, e) =>
                    {
                        Log.Debug("BtnClick ", "in Enter");
                        Intent i = new Intent(this, typeof(SuiteDetails));
                        i.PutExtra("SuiteObj", JsonConvert.SerializeObject(suiteMap[suiteKey]));
                        StartActivity(i);
                    };
                }
                else
                {
                    errorText.Visibility = ViewStates.Visible;
                    //********************Change this

                }
            };

        }
    }
}
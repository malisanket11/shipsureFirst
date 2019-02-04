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
    public class Suite
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<Item> ItemList { get; set; }

        public Suite(string name, string type, List<Item> itemList)
        {
            Name = name;
            Type = type;
            ItemList = itemList;
        }

        public Suite()
        {
            ItemList = new List<Item>();
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public List<Component> ComponentList { get; set; }

        public Item()
        {
            ComponentList = new List<Component>();
        }

        public override string ToString()
        {
            return Name;
        }

    }

    public class Component
    {
        public string Name { get; set; }
        public List<Defect> DefectList { get; set; }

        public Component()
        {
            DefectList = new List<Defect>();
        }

        public override string ToString()
        {
            return Name + ":" + DefectList.Count + " defects";
        }
    }

    public class Defect
    {
        public string Item { get; set; }
        public string Component { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }
        public string AssignedDate { get; set; }
        public string CompletedDate { get; set; }
        public string ClosedDate { get; set; }

        public string ReportedOn { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        public bool Overdue { get; set; }
        public bool Critical { get; set; }
        public bool IsOpen { get; set; }


        public List<ImageView> ImageViewsList { get; set; }

        public Defect()
        {
            ImageViewsList = new List<ImageView>();
        }
        public Defect(string id)
        {

            this.Id = id;
            ImageViewsList = new List<ImageView>();
        }
        public override string ToString()
        {
            return Id + "\n" + ReportedOn + "\n" + Type + "\n" + Overdue + "\n" + Critical;
        }
    }
}
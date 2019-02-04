using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using ShipsureFirst;
using Square.OkHttp;
using FragmentTransaction = Android.App.FragmentTransaction;

namespace ShipsureFirst
{
    [Activity(Label = "AddDefectActivity", Theme = "@style/AppTheme")]
    public class AddDefectActivity : Activity 
    {
        private string ROOT_FOLDER = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).ToString();
        private string OPEN_ISSUE_FOLDER = "/issueOpenImages_image";
        private string RESO_ISSUE_FOLDER = "/issueResolvedImages_image";
        private Button detailsButton;
        private Button imageButton;
        private Button saveButton;
        private Intent intent;
        public static readonly int PickImageId = 1000;
        public static ImageView ImageView { get; set; }
        public Defect defect;

        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_defect);

            checkPermissionForStorage();

            //defect = new Defect(System.Guid.NewGuid().ToString());
            defect = new Defect("Defect002");
            CreateFolders(defect.Id,false);

            detailsButton = (Button)FindViewById(Resource.Id.detailsButton);
            imageButton = (Button)FindViewById(Resource.Id.imageButton);
            detailsButton.Click += DetailsButton_Click;
            imageButton.Click += ImageButton_Click;

            saveButton = (Button) FindViewById(Resource.Id.saveButton);
            saveButton.Click += SaveButton_Click;
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            DefectAddDetailsFragment defectAddDetailsFragment = new DefectAddDetailsFragment();
            ft.Replace(Resource.Id.container1, defectAddDetailsFragment);
            ft.Commit();
        }
        public void CreateFolders(string defectID, Boolean switchToURI)
        {
            //root directory for defect
            string path = Android.OS.Environment.
                GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryDocuments).ToString();
            path += "/" + defectID;
            if (Directory.Exists(path))
            {
                return;
            }
            Directory.CreateDirectory(path);
            string issueOpenImages, issueResolvedImages;

            issueOpenImages = path + "/issueOpenImages_image";
            issueResolvedImages = path + "/issueResolvedImages_image";
            if (switchToURI)
            {
                issueOpenImages = path + "/issueOpenImages_uri";
                issueResolvedImages = path + "/issueResolvedImages_uri";
            }

            //issueOpenImages
            Directory.CreateDirectory(issueOpenImages);

            //issueResolvedImages
            Directory.CreateDirectory(issueResolvedImages);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            DefectAddDetailsFragment defectAddDetailsFragment =
                FragmentManager.FindFragmentById<DefectAddDetailsFragment>(Resource.Id.container1);
            
            defect.Priority = defectAddDetailsFragment.PriorityText.Text;
            defect.Description = defectAddDetailsFragment.DescriptionText.Text;
            defect.Item = defectAddDetailsFragment.ItemNameText.Text;
            defect.Type= defectAddDetailsFragment.TypeText.Text;
            defect.Component = defectAddDetailsFragment.compNameText.Text;
            Log.Debug("new object created:", defect.ToString());
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            DefectAddImageFragment defectAddImage = DefectAddImageFragment.NewInstance(ref defect);
            ft.Replace(Resource.Id.container1, defectAddImage);
            ft.Commit();
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            FragmentTransaction ft = FragmentManager.BeginTransaction();
            DefectAddDetailsFragment defectAddDetailsFragment = new DefectAddDetailsFragment();
            ft.Replace(Resource.Id.container1, defectAddDetailsFragment);
            ft.Commit();
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if ((requestCode == PickImageId) && (resultCode == Result.Ok) && (data != null))
            {
                Bitmap bmp = MediaStore.Images.Media.GetBitmap(this.ContentResolver, data.Data);
                ImageView image = new ImageView(this);
                SaveImage(bmp, ROOT_FOLDER + OPEN_ISSUE_FOLDER + System.Guid.NewGuid() + ".jpg");

            }
        }
        public bool SaveImage(Bitmap bitmap, string filename)
        {
            bool success = false;
            FileStream fs = null;
            try
            {
                using (fs = new FileStream(filename, FileMode.Create))
                {
                    bitmap.Compress(Bitmap.CompressFormat.Jpeg, 8, fs);
                    success = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("SaveImage exception: " + e.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return success;
        }
        public void checkPermissionForStorage()
        {

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) ==
                Android.Content.PM.Permission.Granted)
            {
            }
            else
            {
                ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage, Manifest.Permission.ReadExternalStorage }, 1);
            }
        }
        public override async void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Net;
using Org.Apache.Http.Conn;
using Org.Json;
using Square.OkHttp;
using Path = System.IO.Path;

namespace ShipsureFirst
{
    public class DefectAddImageFragment : Fragment
    {
        private string ROOT_FOLDER = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments).ToString();
        private string OPEN_ISSUE_FOLDER = "issueOpenImages_image";
        private string RESO_ISSUE_FOLDER = "issueResolvedImages_image";
        private Button addImageButton;
        public static readonly int PickImageId = 1000;
        private ImageAdapter adapter;
        private GridView gridview1;
        private List<ImageView> openList;
        OkHttpClient client = new OkHttpClient();
        public Defect Defect { get; set; }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public static  DefectAddImageFragment NewInstance(ref Defect defect)
        {
            DefectAddImageFragment defectAddImageFragment = new DefectAddImageFragment();
            defectAddImageFragment.Defect = defect;
            return defectAddImageFragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             return inflater.Inflate(Resource.Layout.fragment_add_image, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {

            addImageButton = (Button) view.FindViewById(Resource.Id.addImageButton);

            addImageButton.Click += AddImageButton_Click;

            openList = GetImageViews(view, Defect.Id, true);

            gridview1 = view.FindViewById<GridView>(Resource.Id.openGridView);
            adapter = new ImageAdapter(view.Context, openList);
            gridview1.Adapter = adapter;
            
            gridview1.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(Application.Context, args.Position.ToString(), ToastLength.Short).Show();
            };

            //List<ImageView> resolvedList = GetImageViews(view, Defect.Id, true);
            //var gridview2 = view.FindViewById<GridView>(Resource.Id.resolvedGridView);
            //gridview2.Adapter = new ImageAdapter(view.Context, resolvedList);
            //gridview2.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
            //    Toast.MakeText(Application.Context, args.Position.ToString(), ToastLength.Short).Show();
            //};
        }
        public List<ImageView> GetImageViews(View view,string defectId, Boolean Open)
        {
            string folder = Android.OS.Environment.
                                GetExternalStoragePublicDirectory(
                                    Android.OS.Environment.DirectoryDocuments).ToString() + Java.IO.File.Separator + defectId + Java.IO.File.Separator + "issueResolvedImages_image";
            if (Open)
            {
                folder = Android.OS.Environment.
                             GetExternalStoragePublicDirectory(
                                 Android.OS.Environment.DirectoryDocuments).ToString() + Java.IO.File.Separator + defectId + Java.IO.File.Separator + "issueOpenImages_image";
            }

            List<ImageView> imageViewList = new List<ImageView>();
            //fetch image from server here
            var filesList = Directory.GetFiles(folder);
            string path = "";
            Bitmap bmp = null;
            foreach (var file in filesList)
            {
                var filename = Path.GetFileName(file);
                path = Path.GetFullPath(file);
                bmp = BitmapFactory.DecodeFile(path);
                ImageView imageView = new ImageView(view.Context);
                imageView.SetImageBitmap(bmp);
                imageViewList.Add(imageView);
            }
            return imageViewList;
        }

        private void AddImageButton_Click(object sender, EventArgs e)
        {
            Intent intent= new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), PickImageId);
        }

        public override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Bitmap bmp = MediaStore.Images.Media.GetBitmap(Activity.ContentResolver, data.Data);
            ImageView image = new ImageView(View.Context);
            image.SetImageBitmap(bmp);
            SaveImage(bmp, ROOT_FOLDER +"/"+Defect.Id+"/"+ OPEN_ISSUE_FOLDER +"/"+ System.Guid.NewGuid() + ".jpg");

            // add image to server here
            openList.Add(image);
            adapter.NotifyDataSetChanged();
            
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
                Log.Debug("","SaveImage exception: " + e.Message);
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return success;
        }
        public static JSONObject uploadImage(File file)
        {

            try
            {

                final MediaType MEDIA_TYPE_PNG = MediaType.parse("image/png");

                RequestBody req = new MultipartBuilder().SetType(MultipartBody.FORM).addFormDataPart("userid", "8457851245")
                        .addFormDataPart("userfile", "profile.png", RequestBody.create(MEDIA_TYPE_PNG, file)).build();

                Request request = new Request.Builder()
                        .Url("url")
                        .Post(req)
                        .Build();

                OkHttpClient client = new OkHttpClient();
                Response response = client.newCall(request).execute();

                Log.d("response", "uploadImage:" + response.body().string());

                return new JSONObject(response.body().string());

            }
            catch (UnknownHostException | UnsupportedEncodingException e) {
                Log.e(TAG, "Error: " + e.getLocalizedMessage());
            } catch (Exception e)
            {
                Log.e(TAG, "Other Error: " + e.getLocalizedMessage());
            }
            return null;
        }


    }

}
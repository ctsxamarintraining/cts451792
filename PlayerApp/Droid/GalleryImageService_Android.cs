using System;
using PlayerApp.Droid;

using Android.Content;
using Android.App;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Android.Provider;


[assembly: Xamarin.Forms.Dependency(typeof(GalleryImageService_Android))]
namespace PlayerApp.Droid
{
	public class GalleryImageService_Android : Java.Lang.Object, IGalleryImageService
	{
		public event EventHandler<ImageSourceEventArgs> ImageSelected;

		public void SelectImage()
		{
			MainActivity androidContext = (MainActivity)Forms.Context;

			Intent imageIntent = new Intent();
			imageIntent.SetType("image/*");
			imageIntent.SetAction(Intent.ActionGetContent);

			androidContext.ConfigureActivityResultCallback(ImageChooserCallback);
			androidContext.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);           
		}

		private void ImageChooserCallback(int requestCode, Result resultCode, Intent intent)
		{
			if (resultCode == Result.Ok)
			{
				if (ImageSelected != null)
				{
					Android.Net.Uri uri = intent.Data;
					if (ImageSelected != null)
					{
						ImageSource imageSource = ImageSource.FromStream(() => Forms.Context.ContentResolver.OpenInputStream(uri));
						ImageSelected.Invoke(this, new ImageSourceEventArgs(imageSource));

						string doc_id = "";
						using (var c1 = Forms.Context.ContentResolver.Query (uri, null, null, null, null)) {
							c1.MoveToFirst ();
							string document_id = c1.GetString (0);
							doc_id = document_id.Substring (document_id.LastIndexOf (":") + 1);
						}
							
						string selection = Android.Provider.MediaStore.Images.Media.InterfaceConsts.Id + " =? ";
						var cursor = Forms.Context.ContentResolver.Query (MediaStore.Images.Media.ExternalContentUri, null, selection, new string[] {doc_id}, null);
						var colIndex = cursor.GetColumnIndex(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
						cursor.MoveToFirst();
						App.imagePath = cursor.GetString (colIndex);
						cursor.Close ();

					}
				}
			}
		}

	}
}

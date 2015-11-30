using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;

namespace PlayerApp.Droid
{
	[Activity (Label = "PlayerApp.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{

		private Action<int, Result, Intent> _activityResultCallback;

		protected override void OnCreate (Bundle bundle)
		{
			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			App.Path = System.IO.Path.Combine(docsFolder, "SQLite.db3");

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}

		public void ConfigureActivityResultCallback(Action<int, Result, Intent> callback)
		{
			if (callback == null) throw new ArgumentNullException("callback");
			_activityResultCallback = callback;
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			if (_activityResultCallback != null)
			{
				_activityResultCallback.Invoke(requestCode, resultCode, data);
				_activityResultCallback = null;
			}
		}

	}
}


using System;

using Xamarin.Forms;

namespace PlayerApp
{
	public class App : Application
	{

		public static string Path;
		public static string imagePath;

		public App ()
		{
			MainPage = new NavigationPage (new LoginPage ()) 
			{
				BarTextColor = Color.White
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}


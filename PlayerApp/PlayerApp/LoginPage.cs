using System;

using Xamarin.Forms;

namespace PlayerApp
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{

			Title = "Login";

			BackgroundColor = Color.Teal;

			var stackLayout = new StackLayout { Padding = 20 };

			Entry usernameField = new Entry 
			{ 
				Placeholder = "Username" 
			};
			stackLayout.Children.Add(usernameField);

			Entry passwordField = new Entry 
			{ 
				Placeholder = "Password",
				IsPassword = true 
			};
			stackLayout.Children.Add(passwordField);

			Button signInButton = new Button 
			{ 
				Text = "Sign In", 
				TextColor = Color.White 
			};

			signInButton.Clicked += (object sender, System.EventArgs e) => 
			{
				if (usernameField.Text == "s" && passwordField.Text == "s") 
				{
					this.Navigation.PushAsync (new FootballPlayersListPage ());
				} 
				else 
				{
					DisplayAlert ("Error", "Invalid Username or Password", "OK");
				}
			};
					
			stackLayout.Children.Add(signInButton);

			Content = new ScrollView 
			{ 
				Content = stackLayout 
			};

		}

	}
}
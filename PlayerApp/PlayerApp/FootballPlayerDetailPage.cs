using System;

using Xamarin.Forms;

namespace PlayerApp
{
	public class FootballPlayerDetailPage : ContentPage
	{
		public FootballPlayerDetailPage ()
		{
			Title = "Player Details";

			BackgroundColor = Color.Teal;

			var stackLayout = new StackLayout 
			{ 
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Padding = 20 
			};

			Label nameLabel = new Label 
			{
				TextColor = Color.Black,
				Text = "Player Name"
			};
			stackLayout.Children.Add (nameLabel);

			Label nameField = new Label
			{
				TextColor = Color.White
			};
			nameField.SetBinding (Label.TextProperty, "Name");
			stackLayout.Children.Add (nameField);

			Label dateOfBirthLabel = new Label
			{
				TextColor = Color.Black,
				Text = "Date Of Birth"
			};
			stackLayout.Children.Add (dateOfBirthLabel);

			Label dateOfBirthField = new Label
			{
				TextColor = Color.White,
			};
			dateOfBirthField.SetBinding (Label.TextProperty, "DateOfBirth");
			stackLayout.Children.Add (dateOfBirthField);

			Label ageLabel = new Label
			{
				TextColor = Color.Black,
				Text = "Age"
			};
			stackLayout.Children.Add (ageLabel);

			Label ageField = new Label
			{
				TextColor = Color.White,
			};
			ageField.SetBinding (Label.TextProperty, "Age");
			stackLayout.Children.Add (ageField);

			Label countryLabel = new Label
			{
				TextColor = Color.Black,
				Text = "Country"
			};
			stackLayout.Children.Add (countryLabel);

			Label countryField = new Label {
				TextColor = Color.White
			};
			countryField.SetBinding (Label.TextProperty, "Country");
			stackLayout.Children.Add (countryField);

			Image playerImage = new Image 
			{
			};
			playerImage.SetBinding (Image.SourceProperty, "PlayerImage");
			stackLayout.Children.Add (playerImage);

			Content = new ScrollView 
			{ 
				Content = stackLayout 
			};
		}
	}
}



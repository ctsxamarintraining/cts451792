using System;
using SQLite;
using Xamarin.Forms;
using System.Diagnostics;

namespace PlayerApp
{
	public class CreateFootballPlayerPage : ContentPage
	{

		public Entry firstNameField;
		public Entry lastNameField;
		public DatePicker dateOfBirth;
		public Picker countryPicker;
		public Image playerImage;
		public string[] countryList;

		public SQLiteConnection connection;

		public CreateFootballPlayerPage ()
		{

			Title = "Registration";

			BackgroundColor = Color.Teal;

			var stackLayout = new StackLayout 
			{ 
				Orientation = StackOrientation.Vertical,
				Spacing = 10,
				Padding = 20 
			};

			Label firstNameLabel = new Label 
			{
				TextColor = Color.Black,
				Text = "First Name"
			};
			stackLayout.Children.Add (firstNameLabel);

			firstNameField = new Entry
			{
				TextColor = Color.White
			};
			stackLayout.Children.Add (firstNameField);

			Label lastNameLabel = new Label
			{
				TextColor = Color.Black,
				Text = "Last Name"
			};
			stackLayout.Children.Add (lastNameLabel);

			lastNameField = new Entry
			{
				TextColor = Color.White
			};
			stackLayout.Children.Add (lastNameField);

			Label dateOfBirthLabel = new Label
			{
				TextColor = Color.Black,
				Text = "Date Of Birth"
			};
			stackLayout.Children.Add (dateOfBirthLabel);

			dateOfBirth = new DatePicker
			{
				MaximumDate = DateTime.Now
			};
			stackLayout.Children.Add (dateOfBirth);

			Label countryLabel = new Label
			{
				TextColor = Color.Black,
				Text = "Country"
			};
			stackLayout.Children.Add (countryLabel);

			countryList = new string[] 
			{ 
				"India", "Japan", "China", "Korea"
			};

			countryPicker = new Picker 
			{
				Title = null
			};

			foreach (string country in countryList) 
			{
				countryPicker.Items.Add (country);
			}
			stackLayout.Children.Add (countryPicker);

			playerImage = new Image
			{
			};
			stackLayout.Children.Add (playerImage);

			Button playerImageButton = new Button
			{
				Text = "Select an Image"
			};
			playerImageButton.Clicked += imageButtonClicked;
			stackLayout.Children.Add (playerImageButton);

			Button saveButton = new Button 
			{
				Text = "Save",
			};
			saveButton.Clicked += saveButtonClicked;
			stackLayout.Children.Add (saveButton);

			Content = new ScrollView 
			{ 
				Content = stackLayout 
			};
			
		}

		void imageButtonClicked(object sender, System.EventArgs e)
		{
			IGalleryImageService galleryService = Xamarin.Forms.DependencyService.Get<IGalleryImageService>();
			galleryService.ImageSelected += (o, imageSourceEventArgs) => playerImage.Source = imageSourceEventArgs.ImageSource;
			galleryService.SelectImage();

		}

		void saveButtonClicked(object sender, System.EventArgs e)
		{

			if (firstNameField.Text != null && lastNameField.Text != null && countryPicker.SelectedIndex != -1 && App.imagePath != null) {
				
				connection = new SQLiteConnection (App.Path);
				connection.CreateTable<FootballPlayer> ();

				string Name = firstNameField.Text + " " + lastNameField.Text;
				string DateOfBirth = dateOfBirth.Date.ToShortDateString();
				string Country = countryList [countryPicker.SelectedIndex];

				FootballPlayer footballPlayer = new FootballPlayer (Name, DateOfBirth, Country, App.imagePath, false);

				try
				{
					if (connection.Insert (footballPlayer) == 1) 
					{
						DisplayAlert ("Success", "Saved Details", "OK");
						MessagingCenter.Send<CreateFootballPlayerPage> (this, "Reload");
						Navigation.PopAsync ();
					}
					else 
					{
						DisplayAlert ("Error", "Please try again", "OK");
					}
				}
				catch(SQLiteException exception) 
				{
					DisplayAlert ("Duplicate Entry", "Please try again", "OK");
					Debug.WriteLine (exception);
				}
			} 
			else 
			{
				DisplayAlert ("Warning", "Fields cannot be empty", "OK");
			}

		}
	}
}



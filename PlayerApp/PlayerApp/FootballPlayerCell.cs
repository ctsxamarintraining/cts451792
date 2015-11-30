using System;

using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;

namespace PlayerApp
{
	public class FootballPlayerCell : ViewCell
	{

		public SQLiteConnection connection;

		public FootballPlayerCell ()
		{
			connection = new SQLiteConnection (App.Path);

			MenuItem favouriteAction = new MenuItem { Text = "Favourite" };
			favouriteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding("."));
			favouriteAction.Clicked += async (sender, e) => {
				await Task.Run (() => {
					Player player;
					var menuItem = ((MenuItem)sender);
					player = (Player) menuItem.CommandParameter;

					bool isFavourite = !(player.IsFavourite);

					SQLiteCommand command = connection.CreateCommand("UPDATE FootballPlayer SET IsFavourite = ? where Name = ?", isFavourite, player.Name);
					command.ExecuteNonQuery();

				});
				MessagingCenter.Send<FootballPlayerCell> (this, "Favourite");
			};

			ContextActions.Add (favouriteAction);

			MenuItem deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
			deleteAction.Clicked += async (sender, e) => {
				await Task.Run (() => {
					Player player;
					var menuItem = ((MenuItem)sender);
					player = (Player) menuItem.CommandParameter;

					SQLiteCommand command = connection.CreateCommand("DELETE from FootballPlayer where Name = ?", player.Name);
					command.ExecuteNonQuery();
						
				});
				MessagingCenter.Send<FootballPlayerCell> (this, "Delete");
			};

			ContextActions.Add (deleteAction);

			Image PlayerImage = new Image 
			{
				WidthRequest = 50,
				HeightRequest = 50
			};
			PlayerImage.SetBinding (Image.SourceProperty, "PlayerImage");

			Image PlayerFlag = new Image 
			{
				WidthRequest = 50,
				HeightRequest = 30
			};
			PlayerFlag.SetBinding (Image.SourceProperty, "PlayerFlag");


			Label Name = new Label 
			{
				TextColor = Color.Black
			};
			Name.SetBinding (Label.TextProperty, "Name");


			Label DateOfBirth = new Label 
			{
				TextColor = Color.Black
			};
			DateOfBirth.SetBinding (Label.TextProperty, "DateOfBirth");

			Label Age = new Label 
			{
				TextColor = Color.Black,
			};
			Age.SetBinding (Label.TextProperty, "Age");

			StackLayout descriptionLayout = new StackLayout 
			{
				Orientation = StackOrientation.Horizontal,
				Spacing = 10,
				Children = 
				{
					DateOfBirth,
					Age
				}
			};

			StackLayout detailsLayout = new StackLayout 
			{
				Orientation = StackOrientation.Vertical,
				Spacing = 20,
				Children = 
				{
					Name,
					descriptionLayout
				}
			};

			var cellLayout = new StackLayout 
			{
				Spacing = 30,
				Padding = new Thickness (10, 5, 10, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = 
				{ 
					PlayerImage,
					detailsLayout,
					PlayerFlag
				}
			};

			this.View = cellLayout;
		}

	}
}
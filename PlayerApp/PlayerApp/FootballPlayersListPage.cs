using System;

using Xamarin.Forms;

namespace PlayerApp
{
	public class FootballPlayersListPage : ContentPage
	{

		public FootballPlayerListViewModel footballPlayerListViewModel;

		public FootballPlayersListPage ()
		{

			Title = "Football Players";

			NavigationPage.SetHasBackButton (this, false);

			ToolbarItem addButton = new ToolbarItem 
			{
				Text = "+"
			};
			this.ToolbarItems.Add (addButton);

			addButton.Clicked += (object sender, System.EventArgs e) => 
			{
				this.Navigation.PushAsync(new CreateFootballPlayerPage());
			};

			footballPlayerListViewModel = new FootballPlayerListViewModel ();
			this.BindingContext = footballPlayerListViewModel;

			ListView footballPlayersListView = new ListView 
			{
				BackgroundColor = Color.Teal,
				RowHeight = 70,
				ItemTemplate = new DataTemplate (typeof(FootballPlayerCell))
			};
			footballPlayersListView.SetBinding (ListView.ItemsSourceProperty, new Binding ("FootballPlayersList"));

			MessagingCenter.Subscribe<CreateFootballPlayerPage> (this, "Reload", (sender) => {
				footballPlayerListViewModel = new FootballPlayerListViewModel ();
				this.BindingContext = footballPlayerListViewModel;
			});

			MessagingCenter.Subscribe<FootballPlayerCell> (this, "Favourite", (sender) => {
				DisplayAlert("Success","Player Updated","OK");
				footballPlayerListViewModel = new FootballPlayerListViewModel ();
				this.BindingContext = footballPlayerListViewModel;
			});

			MessagingCenter.Subscribe<FootballPlayerCell> (this, "Delete", (sender) => {
				DisplayAlert("Success","Player Deleted","OK");
				footballPlayerListViewModel = new FootballPlayerListViewModel ();
				this.BindingContext = footballPlayerListViewModel;
			});

			footballPlayersListView.ItemSelected += (sender, e) => 
			{
				var footballPlayer = (Player)e.SelectedItem;
				var footballPlayerDetailPage = new FootballPlayerDetailPage();
				footballPlayerDetailPage.BindingContext = footballPlayer;

				Navigation.PushAsync(footballPlayerDetailPage);
			};

			Content = new StackLayout 
			{
				Children = 
				{
					footballPlayersListView
				}
			};
		}

	}
}



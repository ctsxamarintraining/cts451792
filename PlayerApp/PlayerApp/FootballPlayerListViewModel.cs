using System;
using System.Collections.ObjectModel;
using SQLite;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using System.ComponentModel;

namespace PlayerApp
{
	public class FootballPlayerListViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		SQLiteConnection connection;

		private ObservableCollection <Player> _footballPlayersList { get; set; }
		public ObservableCollection <Player> FootballPlayersList 
		{

			get 
			{ 
				return _footballPlayersList; 
			}
			set 
			{ 
				if (_footballPlayersList != value)
				{
					_footballPlayersList = value;
					OnPropertyChanged ("FootballPlayersList");
				} 
			}

		}

		private ICommand _favouriteCommand { get; set; }
		public ICommand FavouriteCommand 
		{

			get 
			{ 
				return _favouriteCommand; 
			}
			set 
			{ 
				if (_favouriteCommand != value)
				{
					_favouriteCommand = value;
					OnPropertyChanged ("FavouriteCommand");
				} 
			}

		}

		public ICommand DeleteCommand { get; protected set; }

		public FootballPlayerListViewModel ()
		{

			getDatabase ();
			FavouriteCommand = new Command<MenuItem> ((menuItem) => {
				
			});

			DeleteCommand = new Command<MenuItem> ((menuItem) => {
				
			});

		}

		void getDatabase()
		{
			FootballPlayersList = new ObservableCollection<Player> ();
			connection = new SQLiteConnection (App.Path);

			SQLiteCommand command = connection.CreateCommand("SELECT * from FootballPlayer ORDER BY IsFavourite DESC , Name");
			var footballPlayersList = command.ExecuteQuery<FootballPlayer> ();

			foreach (FootballPlayer footballPlayer in footballPlayersList) 
			{
				TimeSpan timeSpan = (DateTime.Now - DateTime.Parse(footballPlayer.DateOfBirth));
				double years = timeSpan.Days / 365;

				string playerFlag = null;
				if (footballPlayer.Country == "India") 
				{
					playerFlag = "India.png";
				}
				else if (footballPlayer.Country == "China") 
				{
					playerFlag = "China.png";
				}
				else if (footballPlayer.Country == "Japan") 
				{
					playerFlag = "Japan.png";
				}
				else if (footballPlayer.Country == "Korea") 
				{
					playerFlag = "Korea.png";
				}

				Player player = new Player(footballPlayer.Name, footballPlayer.DateOfBirth, years.ToString(), footballPlayer.Country, playerFlag, footballPlayer.PlayerImage, footballPlayer.IsFavourite);
				FootballPlayersList.Add (player);
			}
		}

		protected virtual void OnPropertyChanged (string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}

	}
}


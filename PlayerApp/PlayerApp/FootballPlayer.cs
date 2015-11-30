using System;
using SQLite;

namespace PlayerApp
{
	public class FootballPlayer
	{
		[Unique]
		public string Name { get; set;}
		public string DateOfBirth { get; set;}
		public string Country { get; set;}
		public string PlayerImage { get; set;}
		public bool IsFavourite { get; set;}

		public FootballPlayer(){}

		public FootballPlayer (string name, string dateOfBirth, string country, string playerImage, bool isFavourite)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
			Country = country;
			PlayerImage = playerImage;
			IsFavourite = isFavourite;
		}
			
	}
}
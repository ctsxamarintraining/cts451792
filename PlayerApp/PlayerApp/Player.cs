using System;

namespace PlayerApp
{
	public class Player
	{
		public string Name { get; set;}
		public string DateOfBirth { get; set;}
		public string Age { get; set;}
		public string Country { get; set;}
		public string PlayerFlag { get; set;}
		public string PlayerImage { get; set;}
		public bool IsFavourite { get; set;}

		public Player(){}

		public Player (string name, string dateOfBirth, string age, string country, string playerFlag, string playerImage, bool isFavourite)
		{
			Name = name;
			DateOfBirth = dateOfBirth;
			Age = age;
			Country = country;
			PlayerFlag = playerFlag;
			PlayerImage = playerImage;
			IsFavourite = isFavourite;
		}
	}
}


using System;
using Xamarin.Forms;

namespace MasterDetail
{
	public class DetailPage : ContentPage
	{
		public DetailPage ()
		{

			this.Title = "Content Page";

			Content = new StackLayout { 
				VerticalOptions = LayoutOptions.Center,
				Children = {
					
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Welcome"
					}

				}
			};

		}
	}
}



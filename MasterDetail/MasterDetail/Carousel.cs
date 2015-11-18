using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MasterDetail
{
	class Carousel : CarouselPage
	{
		public Carousel()
		{
			this.Title = "Carousel Page";

			List<ContentPage> carouselList = new List<ContentPage> (5);
			Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Black };
			foreach (Color c in colors) {
				carouselList.Add (new ContentPage { Content = new StackLayout {
						Children = {
							new BoxView {
								Color = c,
								VerticalOptions = LayoutOptions.FillAndExpand
							}
						}
					}
				});
			}
			this.Children.Add (carouselList [0]);
			this.Children.Add (carouselList [1]);
			this.Children.Add (carouselList [2]);
			this.Children.Add (carouselList [3]);
			this.Children.Add (carouselList [4]);

		}
	}
}


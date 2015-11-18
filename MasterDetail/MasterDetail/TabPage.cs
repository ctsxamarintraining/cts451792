using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;


namespace MasterDetail
{
	class TabPage : TabbedPage
	{
		public TabPage()
		{
			this.Title = "Tabbed Page";

			List<ContentPage> tabList = new List<ContentPage> (4);
			Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue };
			for(int i = 0; i < colors.Count(); i++) {
				tabList.Add (new ContentPage { 
					Title = i.ToString(),
					BackgroundColor=colors[i],
					Content = new StackLayout {
						VerticalOptions = LayoutOptions.Center,
						Children = {
							new Label {
								XAlign = TextAlignment.Center,
								Text = i.ToString()
							}
						}
					}
				});
			}
			this.Children.Add (tabList [0]);
			this.Children.Add (tabList [1]);
			this.Children.Add (tabList [2]);
			this.Children.Add (tabList [3]);
				
		}
	}
}
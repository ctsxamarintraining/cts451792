using System;
using Xamarin.Forms;

namespace MasterDetail
{
	class MasterPage :  MasterDetailPage
	{
		public MasterPage()
		{
			Label header = new Label
			{
				Text = "",
				HorizontalOptions = LayoutOptions.Center
			};

			string[] listViewItems = { "Content Page", "Tabbed Page", "Carousel Page"};

			ListView listView = new ListView
			{
				ItemsSource = listViewItems
			};
					
			this.Master = new ContentPage
			{
				Title = "Master Page",       
				Content = new StackLayout
				{
					Children = 
					{
						header, 
						listView
					}
					}
			};
							
			listView.ItemSelected += (sender, args) =>
			{

				if(listView.SelectedItem.ToString() == "Content Page")
				{
					DetailPage detailPage = new DetailPage();
					this.Detail = new NavigationPage(detailPage);
				}

				if(listView.SelectedItem.ToString() == "Tabbed Page")
				{
					TabbedPage tabbedPage = new TabPage();
					this.Detail = new NavigationPage(tabbedPage);
				}
				if(listView.SelectedItem.ToString() == "Carousel Page")
				{
					CarouselPage carouselPage =new Carousel();
					this.Detail = new NavigationPage(carouselPage);
				}
				this.IsPresented = false;
			};
				
			listView.SelectedItem = listViewItems[0];
		}
	}
}


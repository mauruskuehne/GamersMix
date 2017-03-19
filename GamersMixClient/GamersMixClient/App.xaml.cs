using System.Collections.Generic;

using Xamarin.Forms;

namespace GamersMixClient
{
	public partial class App : Application
	{
		public static bool UseMockDataStore = true;
		public static string BackendUrl = "https://localhost:5000";

		public static IDictionary<string, string> LoginParameters => null;

		public App()
		{
			InitializeComponent();

			GoToMainPage();
		}

		public static void GoToMainPage()
		{
			Current.MainPage = new TabbedPage
			{
				Children = {
					new NavigationPage(new ReglerPage())
					{
						Title = "Regler"
					},
					new NavigationPage(new AboutPage())
					{
						Title = "Einstellungen"
					},
				}
			};
		}
	}
}

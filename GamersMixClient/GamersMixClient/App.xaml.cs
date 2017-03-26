using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Forms.Controls;

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
			Current.MainPage = new MasterDetailPage
			{
				Master = new NavigationPage(new AboutPage())
					{
						Title = "Einstellungen"
					},
				Detail =

					new NavigationPage(new ReglerPage())
					{
						Title = "Regler"
					}

			};
		}
	}
}

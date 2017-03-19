using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GamersMixClient
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";

			if(App.Current.Properties.ContainsKey("URL"))
				URL = (string)App.Current.Properties["URL"] ;
			ConnectCommand = new Command(Connect);
		}

		/// <summary>
		/// Command to open browser to xamarin.com
		/// </summary>
		public ICommand ConnectCommand { get; }

		string _url;
		public string URL
		{
			get { return _url; }
			set { SetProperty(ref _url, value); }
		}

		private async void Connect()
		{
			HttpClient client = new HttpClient();
			try 
			{
				await client.GetStringAsync(URL);

				
				App.Current.Properties["URL"] = URL;
				await Application.Current.SavePropertiesAsync();
				
				await App.Current.MainPage.DisplayAlert("Success!", "connected", "noice!");

			}
			catch(Exception e) 
			{
				await App.Current.MainPage.DisplayAlert("result", "there was an error connecting to the url: " + e.ToString(), "föck!");
			}
		}
	}
}

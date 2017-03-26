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
			Title = "GamersMix";

			if (App.Current.Properties.ContainsKey("SRVNAME"))
				URL = (string)App.Current.Properties["SRVNAME"] ;
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
				string srvName = URL;

				string completeName = $"http://{srvName}:30000/api/soundControllers/get";

				await client.GetStringAsync(completeName);

				
				App.Current.Properties["URL"] = completeName;
				App.Current.Properties["SRVNAME"] = srvName;
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

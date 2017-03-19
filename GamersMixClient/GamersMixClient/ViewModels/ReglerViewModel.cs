using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GamersMixClient
{
	public class ReglerViewModel : BaseViewModel
	{
		public ReglerViewModel()
		{


			GetReglerList();
		}

		public ICommand ConnectCommand { get; }


		public List<string> Regler { get; private set; }

		private async void GetReglerList()
		{
			var URL = (string)App.Current.Properties["URL"];
			HttpClient client = new HttpClient();
			try 
			{
				var str = await client.GetStringAsync(URL);
				Regler = JsonConvert.DeserializeObject<List<string>>(str);
				OnPropertyChanged(nameof(Regler));

			}
			catch(Exception e) 
			{
				await App.Current.MainPage.DisplayAlert("result", "there was an error connecting to the url: " + e.ToString(), "föck!");
			}
		}
	}
}

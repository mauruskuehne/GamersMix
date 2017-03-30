using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	public class SingleReglerVM : BaseViewModel
	{
		private int _loudness;
		public int Loudness
		{
			get { return _loudness; }
			set { _loudness = value; OnPropertyChanged(); }
		}

		public string Name
		{
			get;
			set;
		}
	}

	public class ReglerViewModel : BaseViewModel
	{
		public ReglerViewModel()
		{
			BackgroundTimer();
		}

		private async void BackgroundTimer()
		{
			while (true) 
			{
				await GetReglerList();
				await Task.Delay(5000);
			}

		}


		public ICommand ConnectCommand { get; }

		private void LoudnessChanged(object sender, PropertyChangedEventArgs args) 
		{
			if (args.PropertyName != nameof(SingleReglerVM.Loudness)) 
				return;

			SingleReglerVM vm = (SingleReglerVM)sender;

			HttpClient client = new HttpClient();

			var URL = (string)App.Current.Properties["URL"];

			client.GetStringAsync(URL.Replace("/get", $"/set/{vm.Name}/{vm.Loudness}"));
		}

		public List<SingleReglerVM> Regler { get; private set; }

		private async Task GetReglerList()
		{
			if (!App.Current.Properties.ContainsKey("URL"))
				return;
			
			var URL = (string)App.Current.Properties["URL"];

			if (Regler != null )
			{
				foreach (var item in Regler)
				{
					item.PropertyChanged -= LoudnessChanged;
				}
			}

			Regler = new List<SingleReglerVM>();

			HttpClient client = new HttpClient();
			try 
			{
				var str = await client.GetStringAsync(URL);
				var reglerList = JsonConvert.DeserializeObject<List<string>>(str);

				foreach (var item in reglerList)
				{
					var loudness = Convert.ToInt32(Convert.ToDouble(await client.GetStringAsync(URL + ("/" + item))));

					var vm = new SingleReglerVM { Loudness = loudness, Name = item };
					vm.PropertyChanged += LoudnessChanged;
					Regler.Add(vm);
				}

				OnPropertyChanged(nameof(Regler));
			}
			catch(Exception e) 
			{
				await App.Current.MainPage.DisplayAlert("result", "there was an error connecting to the url: " + e.ToString(), "awww ._.");
			}
		}
	}
}

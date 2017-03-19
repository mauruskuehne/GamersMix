using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GamersMixClient
{
	public class ItemsViewModel : BaseViewModel
	{
		public Command LoadItemsCommand { get; set; }

		public ItemsViewModel()
		{
			Title = "Browse";
			LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

		}

		async Task ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

		}
	}
}

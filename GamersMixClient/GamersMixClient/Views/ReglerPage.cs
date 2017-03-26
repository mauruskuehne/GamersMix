using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GamersMixClient
{
	public partial class ReglerPage : ContentPage
	{
		public ReglerPage()
		{
			InitializeComponent();
		}

		void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			if (e == null) return; // has been set to null, do not 'process' tapped event
			((ListView)sender).SelectedItem = null; // de-select the row
		}
	}
}

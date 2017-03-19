using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GamersMixClient
{
	public partial class NewItemPage : ContentPage
	{
		public NewItemPage()
		{
			InitializeComponent();

			BindingContext = this;
		}

		async void Save_Clicked(object sender, EventArgs e)
		{
		}
	}
}

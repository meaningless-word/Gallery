using Gallery.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new PinCodePage());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}

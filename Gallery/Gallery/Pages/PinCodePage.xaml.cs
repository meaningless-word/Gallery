
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinCodePage : ContentPage
	{
		private static string _pin;

		public PinCodePage()
		{
			InitializeComponent();

			if(App.Current.Properties.TryGetValue("pin", out object pin))
			{
				_pin = pin.ToString();
			}
			else
			{
				entPIN.Placeholder = "введите свой первый pin";
			}
		}
	}
}
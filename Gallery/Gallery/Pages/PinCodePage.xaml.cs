using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gallery.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PinCodePage : ContentPage
	{
		private static string _pin;
		private static bool _isExist = false;
		private static int _attemptsCounter = 0;
		public PinCodePage()
		{
			InitializeComponent();

			// Устанавливаем динамический ресурс с помощью специального метода
			lblTitle.SetDynamicResource(Label.TextColorProperty, "growingColor");
			lblTitle.SetDynamicResource(Label.FontSizeProperty, "growingFont");
			Resources["growingFont"] = 15;
			Resources["growingColor"] = Color.FromRgb(10, 10, 10);

			if (App.Current.Properties.TryGetValue("pin", out object pin))
			{
				_isExist = true;
				_pin = pin.ToString();
				btnSave.Text = "Проверить";
			}
			else
			{
				entPIN.Placeholder = "введите свой первый pin";
				btnSave.Text = "Сохранить";
			}
		}

		private async void btnSave_Clicked(object sender, System.EventArgs e)
		{
			if (_isExist)
			{
				if (_pin == entPIN.Text)
				{
					// Вырнуть "вывеску" в исходное состояние
					Resources["growingFont"] = 15;
					Resources["growingColor"] = Color.FromRgb(10, 10, 10);
				}
				else
				{
					if (_attemptsCounter <= 5)
					{
						// Обновление динамического ресурса
						Resources["growingFont"] = 15 + ++_attemptsCounter * 4;
						Resources["growingColor"] = Color.FromRgb(10 + _attemptsCounter * 40, 10, 10);
					}

					return;
				}
			}
			else
			{
				App.Current.Properties.Add("pin", entPIN.Text);
				_isExist = true;
			}

			await Navigation.PushAsync(new MainPage());
		}
	}
}
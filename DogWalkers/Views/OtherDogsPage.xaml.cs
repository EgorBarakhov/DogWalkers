using DogWalkers.ViewModels;

namespace DogWalkers.Views;

public partial class OtherDogsPage : ContentPage
{
	public OtherDogsPage()
	{
		InitializeComponent();
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		dogsList.ItemsSource = await App.RestService.RefreshDataAsync();
	}

	private void OnDogButton_Clicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		Navigation.PushAsync(new OtherDogPage(new OtherDogViewModel((string)button.BindingContext)));
	}

	private void OnReloadButton_Clicked(object sender, EventArgs e)
	{
		dogsList.ItemsSource = App.RestService.RefreshDataAsync().Result;
	}
}

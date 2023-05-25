using DogWalkers.ViewModels;
namespace DogWalkers.Views;

public partial class DogsListPage : ContentPage
{
	public DogsListPage()
	{
		InitializeComponent();
		dogsList.ItemsSource = App.DogsRepository.GetDogs();
	}

	private void OnReloadButton_Clicked(object sender, EventArgs e)
	{
		dogsList.ItemsSource = App.DogsRepository.GetDogs();
	}

	private void OnCreateDogButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new DogPage(new DogViewModel(null)));
	}

	private void OnDogButton_Clicked(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		Navigation.PushAsync(new DogPage(new DogViewModel((int)button.BindingContext)));
	}
}

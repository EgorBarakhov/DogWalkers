using DogWalkers.ViewModels;
namespace DogWalkers.Views;

public partial class DogPage : ContentPage
{
	public DogViewModel ViewModel { get; private set; }
	public DogPage(DogViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
		BindingContext = ViewModel;
	}

	private void OnSaveDog_Clicked(object sender, EventArgs e)
	{
		if(ViewModel.Name != null && ViewModel.Bio != null && ViewModel.Name.Length < 20)
		{
			App.DogsRepository.SaveDog(ViewModel.Dog);
			_ = App.RestService.SaveDogAsync(ViewModel.Dog);
		}
		Navigation.PopAsync();
	}

	private void OnDeleteDog_Clicked(object sender, EventArgs e)
	{
		App.DogsRepository.DeleteDog(ViewModel.Dog);
		_ = App.RestService.DeleteDogAsync(ViewModel.Guid);
		Navigation.PopAsync();
	}

	private void OnBack_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

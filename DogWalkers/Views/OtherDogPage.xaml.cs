using DogWalkers.ViewModels;

namespace DogWalkers.Views;

public partial class OtherDogPage : ContentPage
{
	public OtherDogViewModel ViewModel { get; }
	public OtherDogPage(OtherDogViewModel vm)
	{
		InitializeComponent();
		ViewModel = vm;
		BindingContext = ViewModel;
	}

	private void OnBack_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
}

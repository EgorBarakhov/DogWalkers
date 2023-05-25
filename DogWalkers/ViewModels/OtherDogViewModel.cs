using System;
using System.ComponentModel;
using DogWalkers.Models;

namespace DogWalkers.ViewModels;

public class OtherDogViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	public Dog Dog { get; private set; }

	public OtherDogViewModel(string guid)
	{
		Dog = App.RestService.GetDogAsync(guid).Result;
	}

	public string Name
	{
		get { return Dog.Name; }
	}

	public string Guid
	{
		get { return Dog.Guid; }
	}

	public string Bio
	{
		get { return Dog.Bio; }
	}

	protected void OnPropertyChanged(string propName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
	}
}


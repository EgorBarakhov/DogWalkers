using System.ComponentModel;
using System.Windows.Input;

using DogWalkers.Models;

namespace DogWalkers.ViewModels;

public class DogViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	public bool isNew = false;

	public Dog Dog { get; private set; }

	public DogViewModel(int? dogId)
	{
		if(dogId != null)
		{
			Dog = App.DogsRepository.GetDog((int)dogId);
		}
		else
		{
			isNew = true;
			Dog = new Dog() { Guid = System.Guid.NewGuid().ToString() };
		}

	}

	public DogsListViewModel dogsListViewModel;

	public string Name
	{
		get { return Dog.Name; }
		set
		{
			if(Dog.Name != value)
			{
				Dog.Name = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public string Guid
	{
		get { return Dog.Guid; }
		set
		{
			if(Dog.Guid != value)
			{
				Dog.Guid = value;
				OnPropertyChanged("Guid");
			}
		}
	}

	public string Bio
	{
		get { return Dog.Bio; }
		set
		{
			if(Dog.Bio != value)
			{
				Dog.Bio = value;
				OnPropertyChanged("Bio");
			}
		}
	}

	protected void OnPropertyChanged(string propName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
	}
}


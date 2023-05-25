using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DogWalkers.Models;

namespace DogWalkers.ViewModels;

public class DogsListViewModel : INotifyPropertyChanged
{
	public List<Dog> Dogs { get; set; }

	public DogsListViewModel()
	{
		Dogs = App.DogsRepository.GetDogs();
	}

	public event PropertyChangedEventHandler PropertyChanged;


	protected void OnPropertyChanged(string propName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
	}
}


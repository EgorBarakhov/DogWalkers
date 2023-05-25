using DogWalkers.Data;
using DogWalkers.Services;

namespace DogWalkers;

public partial class App : Application
{
	public static DogsRepository DogsRepository { get; private set; }
	public static RestService RestService { get; private set; }

	public App(DogsRepository repository, RestService restService)
	{
		InitializeComponent();

		MainPage = new AppShell();

		DogsRepository = repository;
		RestService = restService;
	}
}


using DogWalkers.Data;
using DogWalkers.Services;
using Microsoft.Extensions.Logging;

namespace DogWalkers;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "dogs.db");
		builder.Services.AddSingleton(s =>
			ActivatorUtilities.CreateInstance<DogsRepository>(s, dbPath));
		builder.Services.AddSingleton(s =>
			ActivatorUtilities.CreateInstance<RestService>(s));

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}


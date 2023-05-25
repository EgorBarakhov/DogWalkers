using DogWalkers.Models;
using System;
using System.Text;
using System.Text.Json;

namespace DogWalkers.Services;

public class RestService
{
	HttpClient _client;
	JsonSerializerOptions _serializerOptions;

	public List<Dog> Dogs { get; private set; }
	public RestService()
	{
		_client = new HttpClient();
		_serializerOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			WriteIndented = true
		};
	}

	public async Task<List<Dog>> RefreshDataAsync()
	{
		Dogs = new List<Dog>();

		Uri uri = new Uri(string.Format(Constants.DogsListUrl, string.Empty));
		try
		{
			HttpResponseMessage response = await _client.GetAsync(uri);
			if(response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				Console.WriteLine(content);
				List<Dog> allDogs = JsonSerializer.Deserialize<List<Dog>>(content, _serializerOptions);
				List<Dog> myDogs = App.DogsRepository.GetDogs().ToList();
				Dogs = (List<Dog>)allDogs.Except(myDogs);
			}
		}
		catch(Exception ex)
		{
			Console.WriteLine(@"\tERROR {0}", ex.Message);
		}

		return Dogs;
	}

	public async Task<Dog> GetDogAsync(string guid)
	{
		Dog dog = new Dog();

		Uri uri = new Uri(string.Format(Constants.DogUrl, string.Empty));
		try
		{
			HttpResponseMessage response = await _client.GetAsync(uri);
			if(response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				Console.WriteLine(content);
				dog = JsonSerializer.Deserialize<Dog>(content, _serializerOptions);
			}
		}
		catch(Exception ex)
		{
			Console.WriteLine(@"\tERROR {0}", ex.Message);
		}

		return dog;
	}

	public async Task SaveDogAsync(Dog dog, bool isNewItem = false)
	{
		Uri uri = new Uri(string.Format(Constants.DogUrl, string.Empty));

		try
		{
			string json = JsonSerializer.Serialize<Dog>(dog, _serializerOptions);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

			HttpResponseMessage response = null;
			if(isNewItem)
				response = await _client.PostAsync(uri, content);
			else
				response = await _client.PutAsync(uri, content);

			Console.WriteLine(content);
			Console.WriteLine(response);

			if(response.IsSuccessStatusCode)
				Console.WriteLine(@"\tDog successfully saved.");
		}
		catch(Exception ex)
		{
			Console.WriteLine(@"\tERROR {0}", ex.Message);
		}
	}

	public async Task DeleteDogAsync(string guid)
	{
		Uri uri = new Uri(string.Format(Constants.DogUrl, guid));

		try
		{
			HttpResponseMessage response = await _client.DeleteAsync(uri);
			if(response.IsSuccessStatusCode)
				Console.WriteLine(@"\tDog successfully dseleted.");
		}
		catch(Exception ex)
		{
			Console.WriteLine(@"\tERROR {0}", ex.Message);
		}
	}
}


using System;
using SQLite;
using DogWalkers.Models;

namespace DogWalkers.Data;

public class DogsRepository
{
	SQLiteConnection database;

	public DogsRepository(string dbPath)
	{
		database = new SQLiteConnection(dbPath);
		database.CreateTable<Dog>();
	}

	public List<Dog> GetDogs()
	{
		return database.Table<Dog>().ToList();
	}

	public void SaveDog(Dog dog)
	{
		if(dog.Id != 0)
		{
			database.Update(dog);
		}
		else
		{
			database.Insert(dog);
		}
	}

	public Dog GetDog(int id)
	{
		return database.Table<Dog>()
			.FirstOrDefault(d => d.Id == id);
	}

	public void DeleteDog(int id)
	{
		Dog dog = new() { Id = id };
		DeleteDog(dog);
	}

	public void DeleteDog(Dog dog)
	{
		database.Delete(dog);
	}
}


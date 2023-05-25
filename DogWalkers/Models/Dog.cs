using System;
using SQLite;
namespace DogWalkers.Models;

[Table("dogs")]
public class Dog
{
	[PrimaryKey, AutoIncrement, Column("id")]
	public int Id { get; set; }
	public string Guid { get; set; }
	public string Name { get; set; }
	public string Bio { get; set; }
	public string Image { get; set; }
}


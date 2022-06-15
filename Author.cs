using System;


namespace EpressPublishingHouse
{
	public class Author
	{
		private string name, surname; //imię i nazwisko autora
		private ushort id; //id autora
		private static ushort lastId = 0; //id poprzednio stworzonego autora
		public Author() //konstruktor bezparametrowy
		{
			name = "Gall";
			surname = "Anonim";
			id = ++lastId;
		}
		public Author(string name, string surname) //konstruktor
		{
			this.name = name;
			this.surname = surname;
			id = ++lastId;
		}
		public Author(Author author) //konstruktor kopiujący
		{
			name = author.name;
			surname = author.surname;
			id = author.id;
		}
		public static void DecreaseLastId() { lastId--; } //metoda zmniejszająca lastId
		public void IdFix() { id--; } //metoda zmniejszająca id autora
		public override bool Equals(object? obj) //metoda sprawdzająca, czy dwaj autorzy są tożsami
		{
			if (obj != null)
			{
				if (obj.GetType() == typeof(Author))
				{
					if (((Author)obj).GetName() == this.GetName() &&
						((Author)obj).GetId() == this.GetId() &&
						((Author)obj).GetSurname() == this.GetSurname())
						return true;
					else return false;
				}
				else return false;
			}
			else return false;
		}
		public override string ToString() { return "Id: " + id + " Name: " + name + " Surname: " + surname; } //metoda zwracająca dane autora w postaci tekstowej
		public ushort GetId() { return id; }
		public string GetName() { return name; }
		public string GetSurname() { return surname; }
	}
}

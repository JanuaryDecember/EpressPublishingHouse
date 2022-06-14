using System;


namespace EpressPublishingHouse
{
	public class Author
	{
		private string name, surname;
		private ushort id;
		private static ushort lastId = 0;
		
		public Author()
		{
			name = "Null";
			surname = "Null";
			id = ++lastId;
		}
		public Author(string name, string surname)
		{
			this.name = name;
			this.surname = surname;
			id = ++lastId;
		}

		public Author(string name, string surname, ushort id)
		{
			this.name = name;
			this.surname = surname;
			this.id = id;
		}

		public Author(Author author)
		{
			name = author.name;
			surname = author.surname;
			id = author.id;
		}

		public static void DecreaseLastId()
        {
			lastId--;
        }
		public void IdFix()
        {
			id--;
        }
		public ushort GetId() { return id; }
		public string GetName() { return name; }
		public string GetSurname() { return surname; }
		public override bool Equals(object? obj)
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
		public override string ToString() { return "Id: " + id + " Name: " + name + " Surname: " + surname; }
	}
}

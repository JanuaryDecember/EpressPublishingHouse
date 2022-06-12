using System;


namespace EpressPublishingHouse
{
	public class Author
	{
		private readonly string name, surname;
		private readonly ushort id;
		private static ushort lastId = 0;
		private readonly List<AbstractCreation> orders;

		public Author(string name, string surname)
		{
			this.name = name;
			this.surname = surname;
			this.id = ++lastId;
			orders = new List<AbstractCreation>();
		}

		public Author(Author author)
		{
			this.name = author.name;
			this.surname = author.surname;
			this.id = author.id;
			orders = new List<AbstractCreation>(author.orders);
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

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override string ToString()
		{
			return "Name: " + name + "\nSurname: " + surname;
		}
	}
}

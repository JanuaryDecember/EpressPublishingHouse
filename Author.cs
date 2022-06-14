using System;


namespace EpressPublishingHouse
{
	public class Author
	{
		private string name, surname;
		private ushort id;
		private static ushort lastId = 0;
		private List<AbstractCreation> orders;
		public Author()
		{
			name = "Null";
			surname = "Null";
			id = ++lastId;
			orders = new List<AbstractCreation>();
		}
		public Author(string name, string surname)
		{
			this.name = name;
			this.surname = surname;
			id = ++lastId;
			orders = new List<AbstractCreation>();
		}

		public Author(string name, string surname, ushort id)
		{
			this.name = name;
			this.surname = surname;
			this.id = id;
			orders = new List<AbstractCreation>();
		}

		public Author(Author author)
		{
			name = author.name;
			surname = author.surname;
			id = author.id;
			orders = new List<AbstractCreation>(author.orders);
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
		public override int GetHashCode() { return base.GetHashCode(); } 
		public override string ToString() { return "Name: " + name + "\nSurname: " + surname + "\nId: " + id; }
		public void NewOrder(AbstractCreation creation) { orders.Add(creation); }
		public void ShowOrders()
        {
			//do napisania
        }
		public void FinishOrder() { } //Napisać
	}
}

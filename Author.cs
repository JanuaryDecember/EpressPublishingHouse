using System;


namespace EpressPublishingHouse
{
	public class Author
	{
		private readonly string Name, Surname;
		private readonly ushort id;
		private List<AbstractPrintOrder> orders;

		public Author(string Name, string Surname, ushort id)
		{
			this.Name = Name;
			this.Surname = Surname;
			this.id = id;
		}

		public Author(Author author)
        {
			this.Name = author.Name;
			this.Surname= author.Surname;
			this.id = author.id;
			this.orders = new List<AbstractPrintOrder>(author.orders);
        }

		public ushort GetId()
		{
			return id;
		}

		public string GetName()
		{
			return Name;
		}

		public string GetSurname()
		{
			return Surname;
		}

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
            return "Name: " + Name + "\nSurname" + Surname + ;
        }

    }
}

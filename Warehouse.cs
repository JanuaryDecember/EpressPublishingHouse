using System;
using System.Collections.Generic;

namespace EpressPublishingHouse
{
	public class Warehouse
	{
		private	Dictionary<string, List<Book>> books;
		private List<Magazine> magazines;
		public Warehouse()
		{
			magazines = new List<Magazine>();
			books = new Dictionary<string, List<Book>>();
		}

		public void ShowStock()
        {
			List<string> keylist = new List<string>(books.Keys.ToList());
			Console.WriteLine("Books by genre:\n");
			foreach (string key in keylist)
            {
				Console.WriteLine(key);
				foreach(Book book in books[key])
                {
					Console.WriteLine(book.ToString());
                }
            }
			Console.WriteLine("Magazines:");
			foreach (Magazine magazine in magazines)
            {
				Console.WriteLine(magazine.ToString());
            }
        }

		public void AddBook(string genre, Book book)
        {
			if(!books.ContainsKey(genre))
				books.Add(genre, new List<Book>());
			books[genre].Add(book);
        }

		public void AddMagazine(Magazine magazine)
        {
			magazines.Add(magazine);
        }

		public void AddBookQuantity(uint Quantity, Book book)
        {
			foreach(Book book1 in books[book.GetGenre()])
            {
				if (book1.Equals(book))
                {
					book1.MenageQuantity(Quantity, true);
                }
            }
        }

		public void ReduceBookQuantity(uint Quantity, Book book)
		{
			foreach (Book book1 in books[book.GetGenre()])
			{
				if (book1.Equals(book))
				{
					book1.MenageQuantity(Quantity, false);
				}
			}
		}

		public void AddMagazineQuantity(uint Quantity, Magazine magazine)
        {
			foreach(Magazine magazine1 in magazines)
            {
				if (magazine1.Equals(magazine))
					magazine1.MenageQuantity(Quantity, true);
            }
        }
		public void ReduceMagazineQuantity(uint Quantity, Magazine magazine)
		{
			foreach (Magazine magazine1 in magazines)
			{
				if (magazine1.Equals(magazine))
					magazine1.MenageQuantity(Quantity, false);
			}
		}
		
	}
}
using System;
using System.Collections.Generic;

namespace EpressPublishingHouse
{
	public class Warehouse
	{
		private	Dictionary<string, List<Book>> books; //lista dostępnych książek
		private List<Magazine> magazines; //lista dostępnych czasopism
		public Warehouse() //konstruktor bezparametrowy
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
		public void AddBook(string genre, Book book) //dodawanie książki do magazynu
        {
			if(!books.ContainsKey(genre))
				books.Add(genre, new List<Book>());
			books[genre].Add(book);
        }
		public void AddMagazine(Magazine magazine) //dodawanie czasopisma do magazynu
        {
			magazines.Add(magazine);
        }
		public void AddBookQuantity(uint Quantity, Book book) //zwiększanie ilości książek w magazynie
        {
			foreach(Book book1 in books[book.GetGenre()])
            {
				if (book1.Equals(book))
                {
					book1.MenageQuantity(Quantity, true);
                }
            }
        }
		public void ReduceBookQuantity(uint Quantity, Book book) //zmniejszanie ilości książek w magazynie
		{
			foreach (Book book1 in books[book.GetGenre()])
			{
				if (book1.Equals(book))
				{
					book1.MenageQuantity(Quantity, false);
				}
			}
		}
		public void AddMagazineQuantity(uint Quantity, Magazine magazine) //zwiększanie ilości czasopism w magazynie
		{
			foreach(Magazine magazine1 in magazines)
            {
				if (magazine1.Equals(magazine))
					magazine1.MenageQuantity(Quantity, true);
            }
        }
		public void ReduceMagazineQuantity(uint Quantity, Magazine magazine) //zmniejszanie ilości czasopism w magazynie
		{
			foreach (Magazine magazine1 in magazines)
			{
				if (magazine1.Equals(magazine))
					magazine1.MenageQuantity(Quantity, false);
			}
		}
	}
}
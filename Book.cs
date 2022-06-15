using System;

namespace EpressPublishingHouse
{
    public class Book : AbstractCreation
    {
        private readonly string ISBN; //ISBN książki (13-cyfrowy numer identyfikujący ją)
        private readonly string Genre; //typ książki (np. sensacyjna, romans)
        public Book() : base() //konstruktor bezparametrowy
        {
            ISBN = "0000000000000";
            Genre = "Null";
        }
        public Book(Author author, string Title, float Price, string ISBN, string Genre) : base(author, Title, Price) //konstruktor
        {
            this.ISBN = ISBN;
            this.Genre = Genre;
        }
        public override bool Equals(object? obj) //metoda sprawdzająca, czy dwie książki są tożsame
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(Magazine))
                {
                    if (((Book)obj).GetAuthor().Equals(this.author) &&
                        ((Book)obj).GetTitle() == this.Title &&
                        ((Book)obj).GetPrice() == this.Price &&
                        ((Book)obj).GetQuantity() == this.Quantity &&
                        ((Book)obj).GetGenre() == this.Genre &&
                        ((Book)obj).GetISBN() == this.ISBN)
                        return true;
                    else return false;
                }
                else
                    return false;
            }
            else return false;
        }
        public override string ToString() //przedstawia dane książki w postaci tekstowej
        {
            return "Author:\n" + author.ToString() + "\n"
                + "Title: " + Title + "\n"
                + "Genre: " + Genre + "\n"
                + "ISBN: " + ISBN + "\n"
                + "Price: " + Price + "\n"
                + "Quantity: " + Quantity;
        }
        public string GetISBN() { return this.ISBN; }
        public string GetGenre() { return this.Genre; }
    }
}

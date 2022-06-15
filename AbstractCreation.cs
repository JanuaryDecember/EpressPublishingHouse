using System;

namespace EpressPublishingHouse
{
    public abstract class AbstractCreation
    {
        protected Author author; //autor utworu
        protected string Title; //tytuł utworu
        protected float Price; //cena utworu
        protected uint Quantity = 0; //ilość egzemplarzy w magazynie
        protected AbstractCreation() //konstruktor bezparametrowy
        {
            author = new Author();
            Title = "Title";
            Price = 0;
        }
        protected AbstractCreation(Author author, string Title, float Price) //konstruktor
        {
            this.author = author;
            this.Title = Title;
            this.Price = Price;
        }
        public virtual void SetPrice(float Price) { this.Price = Price; } //ustawianie ceny
        public virtual void MenageQuantity(uint Quantity, bool Option) //zmiana ilości egzemplarzy
        {
            if (Option) //true = zwiększanie ilości egzemplarzy; false = zmniejszanie ilości egzemplarzy
            {
                this.Quantity += Quantity;
            }
            else if (!Option && this.Quantity <= Quantity)
            {
                Console.WriteLine("There are not enough creations!");
            }
            else
            {
                this.Quantity -= Quantity;
            }
        }
        public virtual Author GetAuthor() { return author; }
        public virtual string GetTitle() { return Title; }
        public virtual float GetPrice() { return Price; }
        public virtual uint GetQuantity() { return Quantity; }
    }
}


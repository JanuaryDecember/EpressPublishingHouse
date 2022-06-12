using System;

namespace EpressPublishingHouse
{
    public abstract class AbstractCreation
    {
        protected Author author;
        protected string Title;
        protected float Price;
        protected uint Quantity = 0;
        protected AbstractCreation()
        {
            author = new Author("Null", "Null");
            Title = "Null";
            Price = 0;
        }
        protected AbstractCreation(Author author, string Title, float Price)
        {
            this.author = author;
            this.Title = Title;
            this.Price = Price;
        }
        public virtual Author GetAuthor() { return author; }
        public virtual string GetTitle() { return Title; }
        public virtual float GetPrice() { return Price; }
        public virtual uint GetQuantity() { return Quantity; }
        public virtual void SetPrice(float Price) { this.Price = Price; }
        public virtual void MenageQuantity(uint Quantity, bool Option)
        {
            if (Option)
            {
                this.Quantity += Quantity;
                Console.WriteLine("Added few books!");
            }
            else if (!Option && this.Quantity <= Quantity)
            {
                Console.WriteLine("There are not enough books");
            }
        }
    }
}


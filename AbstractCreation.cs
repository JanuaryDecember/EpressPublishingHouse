using System;

namespace EpressPublishingHouse
{
    public abstract class AbstractCreation
    {
        protected Author author;
        protected string Title;
        protected float Price;
        protected uint Quantity;

        protected AbstractCreation(Author author, string Title, float Price, uint Quantity)
        {
            this.author = author;
            this.Title = Title;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public string GetTitle()
        {
            return Title;
        }

        public float GetPrice()
        {
            return Price;
        }

        public uint GetQuantity()
        {
            return Quantity;
        }

        public void GetPrice(float Price)
        {
            this.Price = Price;
        }

        public void MenageQuantity(uint Quantity, bool Option)
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


﻿using System;

namespace EpressPublishingHouse
{
    public class Book : AbstractCreation
    {
        private readonly uint ISBN;
        private readonly string Genre;
        public Book(Author author, string Title, float Price, uint Quantity, uint ISBN, string Genre) : base(author, Title, Price, Quantity)
        {
            this.ISBN = ISBN;
            this.Genre = Genre;
        }

        public uint GetISBN()
        {
            return this.ISBN;
        }

        public string GetGenre()
        {
            return this.Genre;
        }

        public override bool Equals(object? obj)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
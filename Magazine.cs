using System;

namespace EpressPublishingHouse
{
    public class Magazine : AbstractCreation
    {
        private readonly string ReleaseNumber;
        private readonly string Kind;

        public Magazine() : base()
        {
            ReleaseNumber = "Null";
            Kind = "Null";
        }

        public Magazine(Author author, string Title, float Price, string ReleaseNumber, string Kind) : base(author, Title, Price)
        {
            this.ReleaseNumber = ReleaseNumber;
            this.Kind = Kind;
        }

        public Magazine(Magazine magazine) : base(new Author(magazine.author), magazine.Title, magazine.Price)
        {
            this.ReleaseNumber = magazine.ReleaseNumber;
            this.Kind = magazine.Kind;
        }

        public string GetReleaseNumber()
        {
            return ReleaseNumber;
        }

        public string GetKind()
        {
            return Kind;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(Magazine))
                {
                    if (((Magazine)obj).GetAuthor().Equals(this.author) &&
                        ((Magazine)obj).GetTitle() == this.Title &&
                        ((Magazine)obj).GetPrice() == this.Price &&
                        ((Magazine)obj).GetQuantity() == this.Quantity &&
                        ((Magazine)obj).GetReleaseNumber() == this.ReleaseNumber &&
                        ((Magazine)obj).GetKind() == this.Kind)
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

        public override string ToString()
        {
            return "Author:\n" + author.ToString() + "\n" 
                + "Title: " + Title + "\n" 
                + "Kind: " + Kind + "\n" 
                + "Release number: " + ReleaseNumber + "\n" 
                + "Price: " + Price + "\n" 
                + "Quantity: " + Quantity;
        }
    }
}
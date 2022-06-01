using System;

namespace EpressPublishingHouse
{
    public abstract class AbstractPrintOrder
    {
        protected uint id;
        protected bool PrintOrderType;
        protected Author author;
        public AbstractPrintOrder(uint id, bool printOrderType, Author author, string Title)
        {
            this.id = id;
            this.PrintOrderType = printOrderType;
            this.author = author;
        }

        public uint GetId()
        {
            return id;
        }

        public bool GetPrintOrderType()
        {
            return PrintOrderType;
        }

        public Author GetAuthor()
        {
            return author;
        }
        
    }
}

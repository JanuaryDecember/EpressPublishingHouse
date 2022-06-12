﻿using System;

namespace EpressPublishingHouse
{
    public class PrintOrder
    {
        private readonly uint id;                    //id zlecenia
        private static uint lastId = 0;   //id poprzedniego zlecenia (wspólne dla wszystkich obiektów)
        private readonly string printOrderType = "null";      //jaki typ będzie drukowany (książka czy czasopismo)
        private readonly AbstractCreation creation;  //co dokładnie będzie drukowane
        private uint amount;
        
        public PrintOrder()
        {
            this.id = ++lastId;
            this.creation = new Book();
            this.amount = 0;
            printOrderType = "Bk";
        }
        
        public PrintOrder(AbstractCreation creation, uint amount)
        {
            this.id = ++lastId;
            this.creation = creation;
            this.amount = amount;
            if (creation is Book) printOrderType = "Bk";    //książka
            else if (creation is Magazine) printOrderType = "Mg";                    //czasopismo
        }
        
        public uint GetId() { return id; }
        
        public string GetPrintOrderType() { return printOrderType; }
        
        public AbstractCreation GetCreation() 
        {
            if (printOrderType.Equals("Bk"))
                return (Book)creation;
            else
                return (Magazine)creation;
        }

        public void AddAmount(uint amount)
        {
            this.amount += amount;
        }

        public uint GetAmount()
        {
            return amount;
        }
    }
}

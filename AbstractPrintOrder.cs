using System;

namespace EpressPublishingHouse
{
    public class PrintOrder
    {
        private uint id;                    //id zlecenia
        private static uint lastId = 0;   //id poprzedniego zlecenia (wspólne dla wszystkich obiektów)
        private string printOrderType;      //jaki typ będzie drukowany (książka czy czasopismo)
        private AbstractCreation creation;  //co dokładnie będzie drukowane
        private uint amount;
        public PrintOrder()
        {
            this.id = ++lastId;
            this.creation = new Book();
            this.amount = 0;
            printOrderType = "Ks";
        }
        public PrintOrder(AbstractCreation creation, uint amount)
        {
            this.id = ++lastId;
            this.creation = creation;
            this.amount = amount;
            if (creation is Book) printOrderType = "Ks";    //książka
            else printOrderType = "Cz";                    //czasopismo
        }
        public uint GetId() { return id; }
        public string getPrintOrderType() { return printOrderType; }
        public AbstractCreation getCreation() { return creation; }
        public void finishOrder()
        {

        }
    }
}

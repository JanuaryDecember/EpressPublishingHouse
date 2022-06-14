using System;

namespace EpressPublishingHouse
{
    public class PrintOrder
    {
        private readonly uint id;   //id zlecenia
        private static uint lastId = 0;   //id poprzedniego zlecenia (wspólne dla wszystkich obiektów tej klasy)
        private readonly string printOrderType = "null";      //jaki typ będzie drukowany (książka czy czasopismo)
        private readonly AbstractCreation creation;  //co dokładnie będzie drukowane
        private uint amount; //liczba egzemplarzy do wydruku
        public PrintOrder() //konstruktor bezparametrowy
        {
            id = ++lastId;
            creation = new Book();
            amount = 0;
            printOrderType = "Bk";
        }
        public PrintOrder(AbstractCreation creation, uint amount) //konstruktor
        {
            this.id = ++lastId;
            this.creation = creation;
            this.amount = amount;
            if (creation is Book && ((Book)creation).GetGenre() == "Album") printOrderType = "Al";    //typ dla albumu
            if (creation is Book) printOrderType = "Bk";    //typ dla książki
            else if (creation is Magazine) printOrderType = "Mg";     //typ dla czasopisma
        }
        public uint GetId() { return id; }
        public string GetPrintOrderType() { return printOrderType; }
        public AbstractCreation GetCreation() { return creation; }
        public uint GetAmount() { return amount; }
        public void Finish(PublishingHouse Epress) //zlecenie zakończone
        {
            creation.MenageQuantity(amount,true); //zwiększenie ilości utworu o ilość wydrukowanych
            if (printOrderType == "Al" || printOrderType == "Bk") 
            {
                string genre = ((Book)creation).GetGenre();
                (Epress.GetWarehouse()).AddBook(genre, (Book)creation); //jeśli album lub inny rodzaj książki, dodawana jest książka do magazynu
            }
            else (Epress.GetWarehouse()).AddMagazine((Magazine)creation); //jeśli czasopismo, dodawane jest czasopismo do magazynu
        }
        public string toString()
        {
            return (id.ToString() + " - " + printOrderType.ToString() + " - " + creation.GetTitle() + " - " + amount.ToString());
        }
    }
}

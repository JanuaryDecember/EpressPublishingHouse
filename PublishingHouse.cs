using System;

namespace EpressPublishingHouse
{
    public class PublishingHouse
    {
        
        private List<PrintingHouse> printingHouseList;
        private List<Author> authors;
        private List<Contract> contracts;
        private Warehouse warehouse;
        private List<Book> books;
        private List<Magazine> magazines;

        public PublishingHouse(Warehouse warehouse)
        {
            printingHouseList = new List<PrintingHouse>();
            authors = new List<Author>();
            contracts = new List<Contract>();
            books = new List<Book>();
            magazines = new List<Magazine>();
            this.warehouse = warehouse;
        }

        // // // // // // // Tak chyba lepiej, bo patrzylem ze troche skomplikowany byl ten kod i sprawdzilem czy mozna tak zrobic i mozna
        public int AddBook(AbstractCreation book)
        {
            if(book is Book && !(books.Exists(i => i.Equals(book))))
            {
                books.Add((Book)book);
                return 1;
            }
            else
                return 0;
        }

        public int AddMagazine(AbstractCreation magazine)
        {
            if (magazine is Magazine && !(books.Exists(i => i.Equals(magazine))))
            {
                magazines.Add((Magazine)magazine);
                return 1;
            }
            else
                return 0;
        }
        // // // // // // //

        public void Print(PrintOrder order)
        {
            if (order.GetPrintOrderType() == "Al")
            {
                foreach (PrintingHouse printingHouse in printingHouseList)
                    if (printingHouse.GetAbleToPrintAlbums())
                        printingHouse.AddNewPrintOrder(order); //bo wiemy, że jest tylko jedna taka drukarnia
            }
            else
            {
                uint minimum = uint.MaxValue;
                int indeks = 0;
                foreach (PrintingHouse printingHouse in printingHouseList)
                    if (printingHouse.HowBusy() <= minimum)
                    {
                        minimum = printingHouse.HowBusy(); //znajduje najmniej zajętą drukarnię
                        indeks = printingHouseList.IndexOf(printingHouse); //zapisuje indeks tej drukarni
                    }
                (printingHouseList.ElementAt(indeks)).AddNewPrintOrder(order);
            }
        }

        public Warehouse GetWarehouse() { return warehouse; }
    }
}

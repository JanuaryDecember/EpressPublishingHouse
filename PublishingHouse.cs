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
            //to ogarnę
        }
    }
}

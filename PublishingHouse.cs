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

        public void AddAuthor()
        {
            Console.WriteLine("Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();
            Author author = new Author(name, surname);
            authors.Add(author);
        }

        public Author GetAuthorByIndex(int i)
        {
            return authors[i];
        }

        public string GetAuthors()
        {
            string authorlist = "";
            uint i = 1;
            foreach (Author author in authors)
            {
                authorlist += i.ToString() + ".\n  Name: " + author.GetName() + "\n  Surname: " + author.GetSurname() + "\n  Id: " + author.GetId() + "\n";
                i++;
            }
            return authorlist;
        }

        public void RemoveAuthor()
        {
            if (GetAuthors().Equals(""))
            {
                Console.WriteLine("No authors found!\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Choose which author you want to delete:");
                Console.WriteLine(GetAuthors());
                authors.RemoveAt(Int32.Parse(Console.ReadLine()) - 1);
                
            }
        }

        public void AddContract()
        {
            if (GetAuthors().Equals(""))
            {
                Console.Clear();
                Console.WriteLine("No authors detected! You can't make a contract without any worker!");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Choose contract type:\n1.Contract of employment\n2.Contract of mandate\n3.Go back");
                int i = Int32.Parse(Console.ReadLine());
                if (i == 1)
                {
                    Console.WriteLine("Choose author:\n");
                    Console.WriteLine(GetAuthors());
                    int j = Int32.Parse(Console.ReadLine());
                }
            }
        }

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

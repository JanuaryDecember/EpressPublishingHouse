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
        private List<AbstractCreation> orders;
        private List<AbstractCreation> readyToPrint;

        public PublishingHouse(Warehouse warehouse)
        {
            printingHouseList = new List<PrintingHouse>();
            authors = new List<Author>();
            contracts = new List<Contract>();
            books = new List<Book>();
            magazines = new List<Magazine>();
            orders = new List<AbstractCreation>();
            readyToPrint = new List<AbstractCreation>();
            this.warehouse = warehouse;
            printingHouseList.Add(new PrintingHouse(true));
            printingHouseList.Add(new PrintingHouse(false));
            printingHouseList.Add(new PrintingHouse(false));
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
                Console.WriteLine("No authors detected! You can't make a contract without any workers!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
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
                    contracts.Add(new Contract(authors[j-1], true));
                }
                else if (i == 2)
                {
                    Console.WriteLine("Choose author:\n");
                    Console.WriteLine(GetAuthors());
                    int j = Int32.Parse(Console.ReadLine());
                    contracts.Add(new Contract(authors[j - 1], false));
                }
            }
        }

        public void MakeOrder()
        {
            if (GetAuthors().Equals(""))
            {
                Console.Clear();
                Console.WriteLine("No authors detected! You can't make an order without any workers!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Choose author:\n");
                Console.WriteLine(GetAuthors());
                int j = Int32.Parse(Console.ReadLine());
                Author author = new Author(authors[j-1]);
                Console.WriteLine("Choose order type:\n1.Book\n2.Magazine");
                j = Int32.Parse(Console.ReadLine());
                if(j == 1)
                {
                    string title, genre, isbn;
                    float price;
                    Console.WriteLine("Title: ");
                    title = Console.ReadLine();
                    Console.WriteLine("Genre: ");
                    genre = Console.ReadLine();
                    Console.WriteLine("isbn: ");
                    isbn = Console.ReadLine();
                    Console.WriteLine("Price: ");
                    price = float.Parse(Console.ReadLine());
                    orders.Add(new Book(author, title, price, genre, isbn));
                }
                else if (j == 2)
                {
                    string title, kind, releasenumber;
                    float price;
                    Console.WriteLine("Title: ");
                    title = Console.ReadLine();
                    Console.WriteLine("kind: ");
                    kind = Console.ReadLine();
                    Console.WriteLine("releasenumber: ");
                    releasenumber = Console.ReadLine();
                    Console.WriteLine("Price: ");
                    price = float.Parse(Console.ReadLine());
                    orders.Add(new Magazine(author, title, price, releasenumber, kind));
                }
            }
        }

        public string GetOrders()
        {
            string orderlist = "";
            int i = 1;
            foreach (AbstractCreation order in orders)
            {
                orderlist += i.ToString() + ".\nAuthor:\n" + order.GetAuthor().ToString() + "\nTitle: " + order.GetTitle() +
                    "\nGenre: " + order.GetType() + "\n";
                i++;
            }
            return orderlist;
        }

        public string GetContractsAndOrders()
        {
            string list = "Orders:\n";
            int i = 1;
            foreach (AbstractCreation order in orders)
            {
                list += i.ToString() + ".\nAuthor: " + order.GetAuthor().ToString() + "\nTitle: " + order.GetTitle() +
                    "\nGenre: " + order.GetType() + "\n";
                i++;
            }
            list += "\nContracts:\n";
            i = 1;
            foreach (Contract contract in contracts)
            {
                list += i.ToString() + ".\nId: " + contract.GetContractId() + "\nContract type: " + contract.ContractTypeToString() + "\nAuthor: " + contract.GetAuthor().ToString() + "\n";
                i++;
            }
            return list;
        }

        public void Buy()
        {
            warehouse.ShowStock();
            Console.Write("Choose book or magazine:");
            Console.ReadLine();

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

        public void FinishOrder()
        {
            if (!GetOrders().Equals(""))
            {
                Console.WriteLine("Choose which order to finish: ");
                Console.WriteLine(GetOrders());
                int iter = Int32.Parse(Console.ReadLine());
                readyToPrint.Add(orders[iter - 1]);
                orders.RemoveAt(iter - 1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No orders found!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public string GetReadyToPrint()
        {
            string orderlist = "";
            int i = 1;
            foreach (AbstractCreation order in readyToPrint)
            {
                orderlist += i.ToString() + ".\nAuthor:\n" + order.GetAuthor().ToString() + "\nTitle: " + order.GetTitle() +
                    "\nGenre: " + order.GetType() + "\n";
                i++;
            }
            return orderlist;
        }

        public void NewPrintOrder()
        {
            if (!GetReadyToPrint().Equals(""))
            {
                Console.WriteLine("Choose order ready to print:\n");
                Console.WriteLine(GetReadyToPrint());
                int iter = Int32.Parse(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("How many creations to print: ");
                int amount = Int32.Parse(Console.ReadLine());
                Print(new PrintOrder(readyToPrint[iter - 1], (ushort)amount));
                readyToPrint.RemoveAt(iter - 1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There are no orders that can be printed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
 
            
        }

        public string GetPrintOrders()
        {
            string orderlist = "";
            int i = 1;
            int j = 1;
            foreach (PrintingHouse printingHouse in printingHouseList)
            {
                foreach(PrintOrder printorder in printingHouse.GetPrintOrders())
                {
                    orderlist += "Printing house no " + j.ToString() + ".\n" + i.ToString() + ".\n PrintOrder: " + printorder.toString() + "\n";
                }
                j++;
            }
            return orderlist;
        }

        public void FinishPrinting(PublishingHouse epress)
        {
            Console.WriteLine(GetPrintOrders());
            Console.WriteLine("Choose number of printing house: ");
            int j = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Choose order id to finish: ");
            int i = Int32.Parse(Console.ReadLine());
            PrintOrder pr = printingHouseList[j - 1].GetPrintOrders().Find(o => o.GetId().Equals(i));
            printingHouseList[j - 1].EndOrder((uint)i, epress);
        }

        public void ShowStock()
        {
            warehouse.ShowStock();
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

using System.Runtime.Serialization;
using System.Xml;
namespace EpressPublishingHouse
{
    class Program
    {
        static void SaveData<T>(T obj, string filepath)
        {
            var serializer = new DataContractSerializer(typeof(T));
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                IndentChars = "\t",
            };
            var writer = XmlWriter.Create(filepath, settings);
            serializer.WriteObject(writer, obj);
        }

        static T LoadData<T>(string filepath)
        {
            var filestream = new FileStream(filepath, FileMode.Open);
            var reader = XmlDictionaryReader.CreateTextReader(filestream, new XmlDictionaryReaderQuotas());
            var serializer = new DataContractSerializer(typeof(T));
            T obj = (T)serializer.ReadObject(reader, true);
            reader.Close();
            filestream.Close();
            return obj;
        }

        private static void ShowMenu(ushort c)
        {
            switch (c)
            {
                case 0:
                    Console.WriteLine("1.Authors management \n2.Contracts management \n3.Printing Managemant\n4.Shop\n5.Exit");
                    break;
                case 1:
                    Console.WriteLine("1.Add a author \n2.Remove a author\n3.Show authors \n4.Go back");
                    break;
                case 2:
                    Console.WriteLine("1.New contract \n2.New order\n3.Show contracts and orders \n4.Finish all contarcts with author\n5.Finish order\n6.Go back");
                    break;
                case 3:
                    Console.WriteLine("1.New print order \n2.Show orders\n3.Finish order\n4.Go back");
                    break;
                case 4:
                    Console.WriteLine("1.Buy a creation \n2.Show all creations\n3.Go back");
                    break;
            }
        }
        static void Main()
        {
            PublishingHouse Epress = new PublishingHouse(new Warehouse());
            if (File.Exists("epress"))
                Epress = LoadData<PublishingHouse>("epress");
            bool shouldStop = false;
            while (!shouldStop)
            {
                ShowMenu(0);
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        ShowMenu(1);
                        switch(Int32.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Epress.AddAuthor();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                Epress.RemoveAuthor();
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine(Epress.GetAuthors());
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        ShowMenu(2);
                        switch (Int32.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Epress.AddContract();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                Epress.MakeOrder();
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine(Epress.GetContractsAndOrders());
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                Epress.FinishAllContracts();
                                Console.Clear();
                                break;
                            case 5:
                                Console.Clear();
                                Epress.FinishOrder();
                                Console.Clear();
                                break;
                            case 6:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        ShowMenu(3);
                        switch (Int32.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Epress.NewPrintOrder();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine(Epress.GetPrintOrders());
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;  
                            case 3:
                                Console.Clear();
                                Epress.FinishPrinting(Epress);
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        ShowMenu(4);
                        switch (Int32.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Epress.Buy();
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                Epress.ShowStock();
                                Console.WriteLine("Press any key to continue...");
                                Console.ReadKey();
                                break;
                            case 3:
                                Console.Clear();
                                break;
                        }
                        Console.Clear();
                        break;
                    case 5:
                        shouldStop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Choose wisely!");
                        break;
                }
            }
            SaveData<PublishingHouse>(Epress, "epress");
            Console.WriteLine("Program has ended!\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

namespace EpressPublishingHouse
{
    class Program
    {
        private static void ShowMenu(ushort c)
        {
            switch (c)
            {
                case 0:
                    Console.WriteLine("1.Authors management \n2. Contracts management \n3. Printing Managemant\n4. Shop\n5.Exit");
                    break;
                case 1:
                    Console.WriteLine("1.Add a author \n2.Remove a author\n3.Show authors \n4.Go back");
                    break;
                case 2:
                    Console.WriteLine("1.New contract \n2.New order\n3.Show contracts and orders \n4.Go back");
                    break;
                case 3:
                    Console.WriteLine("1.New print order \n2.Show orders\n3.Go back");
                    break;
                case 4:
                    Console.WriteLine("1.Buy a creation \n2.Show all creations\n3.Go back");
                    break;
            }
        }
        static void Main()
        {
            PublishingHouse Epress = new PublishingHouse(new Warehouse());
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
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                break;
                        }
                        break;
                    case 2:
                        ShowMenu(2);
                        switch (Int32.Parse(Console.ReadLine()))
                        {
                            case 1:
                                
                                break;
                        }
                        break;
                    case 3:
                        ShowMenu(3);
                        break;
                    case 4:
                        ShowMenu(4);
                        break;
                    case 5:
                        shouldStop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Choose wisely!");
                        break;
                }
            }
            Console.WriteLine("Program has ended!\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}

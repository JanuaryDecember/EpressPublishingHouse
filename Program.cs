using System;


namespace EpressPublishingHouse
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("1. Exit");
        }
        static void Main()
        {
            PublishingHouse Epress = new PublishingHouse(new Warehouse());
            var shouldStop = false;
            var choice = 0;
            while (!shouldStop)
            {
                ShowMenu();
                choice = Int32.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        shouldStop = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option! Choose wisely!");
                        break;
                }
            }
            Console.WriteLine("Program has ended...");
            Console.ReadKey();
        }
    }
}

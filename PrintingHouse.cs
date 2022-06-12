using System;

namespace EpressPublishingHouse
{
	public class PrintingHouse
	{
		private readonly List<PrintOrder> printOrders;
		private readonly bool ableToPrintAlbums;
		public PrintingHouse(bool ableToPrintAlbums)
        {
            printOrders = new List<PrintOrder>();
            this.ableToPrintAlbums = ableToPrintAlbums;
        }
        public PrintingHouse(PrintingHouse printingHouse)
        {
            ableToPrintAlbums = printingHouse.ableToPrintAlbums;
            printOrders = new List<PrintOrder>(printingHouse.printOrders);
        }
        public void AddNewPrintOrder(PrintOrder printOrder) { printOrders.Add(printOrder); }
        public void ShowOrders()
        {
            uint i = 1;
            foreach (PrintOrder printOrder in printOrders)
            {
                Console.WriteLine(i + " " + printOrder.ToString());
                i++;
            }
        }
        public void EndOrder(PrintOrder printOrder)
        {
            foreach(PrintOrder printOrder1 in printOrders)
            {
                if (printOrder1.Equals(printOrder))
                {
                    printOrder1.Finish();
                    printOrders.Remove(printOrder1);
                }
            }
        }
        public List<PrintOrder> GetPrintOrders() { return printOrders; }
        public bool GetAbleToPrintAlbums() { return ableToPrintAlbums; }
        public uint HowBusy() //sprawdzanie "zajętości" drukarni. Ważne przy jej wyborze
        {
            uint points = 0; //Im większa liczba punktów, tym bardziej zajęta drukarnia
            foreach (PrintOrder p in printOrders)
            {
                if (p.GetPrintOrderType() == "Mg") points += p.GetAmount() * 5;     //jedno czasopismo to 5 punktów
                else if (p.GetPrintOrderType() == "Bk") points += p.GetAmount() * 10;   //jedna książka to 10 punktów
                else if (p.GetPrintOrderType() == "Al") points += p.GetAmount() * 20;   //jeden album to 20 punktów
            }
            return points;
        }
    }
}

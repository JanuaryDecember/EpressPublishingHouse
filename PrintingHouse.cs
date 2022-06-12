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

        public void AddNewPrintOrder(PrintOrder printOrder)
        {
            printOrders.Add(printOrder);
        }

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
                    printOrders.Remove(printOrder1);
            }
        }
        public List<PrintOrder> GetPrintOrders()
        {
            return printOrders;
        }

        public bool GetAbleToPrintAlbums()
        {
            return ableToPrintAlbums;
        }
    }
}

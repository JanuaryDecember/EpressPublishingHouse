using System;

namespace EpressPublishingHouse
{
	public class PrintingHouse
	{
		private List<PrintOrder> printOrders; //lista zleceń drruku
		private bool ableToPrintAlbums; //czy drukarnia jest w stanie drukować albumy

        public PrintingHouse() //konstruktor bezparametrowy
        {
            printOrders = new List<PrintOrder>();
            ableToPrintAlbums = false;
        }
		public PrintingHouse(bool ableToPrintAlbums) //konstruktor
        {
            printOrders = new List<PrintOrder>();
            this.ableToPrintAlbums = ableToPrintAlbums;
        }
        public PrintingHouse(PrintingHouse printingHouse) //konstruktor kopiujący
        {
            ableToPrintAlbums = printingHouse.ableToPrintAlbums;
            printOrders = new List<PrintOrder>(printingHouse.printOrders);
        }
        public void AddNewPrintOrder(PrintOrder printOrder) { printOrders.Add(printOrder); } //dodawanie zlecenia do listy
        public void ShowOrders() //wyświetlenie zleceń
        {
            uint i = 1;
            Console.WriteLine("Nr. - ID - Type - Title - Amount");
            foreach (PrintOrder printOrder in printOrders)
            {
                Console.WriteLine(i + " - " + printOrder.toString());
                i++;
            }
        }
        public void EndOrder(uint id, PublishingHouse Epress) //kończenie zlecenia
        {
            PrintOrder pr = printOrders.Find(o => o.GetId().Equals(id));
            pr.Finish(Epress); //podejmowane są odpowiednie kroki kończące zlecenie
            printOrders.Remove(pr); //zlecenie jest usuwane z listy
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

using System;

namespace EpressPublishingHouse
{
    public class PublishingHouse
    {
        private List<PrintingHouse> printingHouseList;
        private List<Author> authors;
        private List<Contract> contracts;
        private Warehouse warehouse;

        public PublishingHouse(Warehouse warehouse)
        {
            this.printingHouseList = new List<PrintingHouse>();
            this.authors = new List<Author>();
            this.contracts = new List<Contract>();
            this.warehouse = warehouse;
        }
    }
}

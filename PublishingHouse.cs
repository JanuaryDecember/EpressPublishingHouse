using System;

namespace EpressPublishingHouse
{
    public class PublishingHouse
    {
        private List<PrintingHouse> printingHouseList;
        private List<Author> authors;
        private List<Contract> contracts;
        private Warehouse warehouse;
        private List<AbstractCreation> creations;
        public PublishingHouse(Warehouse warehouse)
        {
            this.printingHouseList = new List<PrintingHouse>();
            this.authors = new List<Author>();
            this.contracts = new List<Contract>();
            this.warehouse = warehouse;
            this.creations = new List<AbstractCreation>();
        }
        public int AddCreation(AbstractCreation creation)
        {
            if (creation is Book) //Jeśli dzieło jest książką
            {
                foreach (AbstractCreation c in creations)
                {
                    if (c is Book && ((Book)c).Equals((Book)creation)) return 1;    //sprawdza, czy nie ma już na liście takiego tytułu. Jeśli jest, kończy działanie metody
                }
                creations.Add(creation); //Jeśli doszło do tego miejsca, to nie ma na liście takiego tytułu i jest on dodawany
                return 1;
            }
            else if (creation is Magazine) //Jeśli dzieło jest czasopismem (takie same działanie jak wyżej)
            {
                foreach (AbstractCreation c in creations)
                {
                    if (c is Magazine && ((Magazine)c).Equals((Magazine)creation)) return 1;
                }
                creations.Add(creation); 
                return 1;
            }
            return 0;
        }
    }
}

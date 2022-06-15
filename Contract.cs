using System;

namespace EpressPublishingHouse
{
    public class Contract
    {
        private readonly uint contractId; //id umowy
        private static uint lastId = 1; //id, które można tworzonej danej umowie
        private readonly Author author; //autor, z którym umowa jest zawierana
        private bool contractType; //typ umowy false = umowa o dzieło; true = umowa o pracę;
        public Contract() //konstruktor bezparametrowy
        {
            contractId = lastId;
            author = new Author();
            contractType = false;
            lastId++;
        }
        public Contract(Author author, bool contractType) //konstruktor
        {
            this.author = author;
            this.contractType = contractType;
            this.contractId = lastId;
            lastId++;
        }
        public Contract(Contract contract) //konstruktor kopiujący
        {
            contractType = contract.contractType;
            author = contract.author;
            contractId = lastId;
            lastId++;
        }
        public string ContractTypeToString() //zwraca typ umowy w postaci tekstowej
        {
            if (contractType)
                return "Contract of employment";
            else
                return "Contract of mandate";
        }
        public void ChangeContractType() //pozwala zmienić typ zawartej umowy
        {
            Console.WriteLine("Choose type:\n1.Contract of employment\n2.Contract of mandate");
            int j = Int32.Parse(Console.ReadLine());
            if ( j == 1)
                contractType = true;
            else if(j == 2)
                contractType = false;
        }
        public Author GetAuthor() { return author; }
        public bool GetContractType() { return contractType; }
        public uint GetContractId() { return contractId; }
    }
}

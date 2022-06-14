using System;

namespace EpressPublishingHouse
{
    public class Contract
    {
        private readonly uint contractId;
        private static uint lastId = 1;
        private readonly Author author;
        private bool contractType;

        public Contract()
        {
            contractId = lastId;
            author = new Author();
            contractType = false;
            lastId++;
        }

        public Contract(Author author, bool contractType)
        {
            this.author = author;
            this.contractType = contractType;
            this.contractId = lastId;
            lastId++;
        }

        public Contract(Contract contract)
        {
            contractType = contract.contractType;
            author = contract.author;
            contractId = lastId;
            lastId++;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public bool GetContractType()
        {
            return contractType;
        }

        public string ContractTypeToString()
        {
            if (contractType)
                return "Contract of employment";
            else
                return "Contract of mandate";
        }

        public uint GetContractId()
        {
            return contractId;
        }

        public void ChangeContractType()
        {
            Console.WriteLine("Choose type:\n1.Contract of employment\n2.Contract of mandate");
            int j = Int32.Parse(Console.ReadLine());
            if ( j == 1)
                contractType = true;
            else if(j == 2)
                contractType = false;
        }
    }
}

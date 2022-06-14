using System;

namespace EpressPublishingHouse
{
    public class Contract
    {
        private readonly uint contractId;
        private static uint lastId;
        private readonly Author author;
        private ushort contractType;

        public Contract()
        {
            contractId = lastId;
            author = new Author();
            contractType = 0;
            lastId++;
        }

        public Contract(Author author, ushort ContractType)
        {
            this.author = author;
            this.contractType = ContractType;
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

        public ushort GetContractType()
        {
            return contractType;
        }

        public uint GetContractId()
        {
            return contractId;
        }

        public void ChangeContractType()
        {
            Console.WriteLine("Choose type: ");
            contractType = (ushort)Int32.Parse(Console.ReadLine());
        }
    }
}

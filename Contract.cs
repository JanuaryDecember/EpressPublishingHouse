using System;

namespace EpressPublishingHouse
{
    public class Contract
    {
        private readonly Author author;
        private bool ContractType;

        public Contract(Author author, bool ContractType)
        {
            this.author = author;
            this.ContractType = ContractType;
        }

        public Contract(Contract contract)
        {
            ContractType = contract.ContractType;
            author = contract.author;
        }

        public Author GetAuthor()
        {
            return author;
        }

        public string GetContractType()
        {
            if (!ContractType)
                return "Contract of employment";
            else return "Contract of commission";
        }

        public void ChangeContractType()
        {
            ContractType = !ContractType;
        }
    }
}

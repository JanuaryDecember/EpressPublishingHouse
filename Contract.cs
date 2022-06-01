using System;

namespace EpressPublishingHouse
{
    public class Contract
    {
        private readonly uint ContractId;
        private readonly Author author;
        private bool ContractType;

        public Contract(Author author, bool ContractType, uint ContractId)
        {
            this.author = author;
            this.ContractType = ContractType;
            this.ContractId = ContractId;
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

        public bool GetContractType()
        {
            return ContractType;
        }

        public string ContractTypeToString()
        {
            if (!ContractType)
                return "Contract of employment";
            else return "Contract of commission";
        }

        public uint GetContractId()
        {
            return ContractId;
        }

        public void ChangeContractType()
        {
            ContractType = !ContractType;
        }
    }
}

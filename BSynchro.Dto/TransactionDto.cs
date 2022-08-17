using System;

namespace BSynchro.Dto
{
    public class TransactionDto
    {
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public string AccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}

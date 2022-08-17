using BSynchro.DataAccess.Abstraction.Models;

namespace BSynchro.DataAccess.Models
{
    public class Transaction : BaseEntity
    {
        public string TransactionId { get; set; }
        public string TransactionType { get; set; }
        public double Amount { get; set; }
        public Account Account { get; set; }
    }
}

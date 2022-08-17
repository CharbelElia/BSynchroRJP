using BSynchro.DataAccess.Abstraction.Models;
using System.Collections.Generic;

namespace BSynchro.DataAccess.Models
{
    public class Account : BaseEntity
    {
        public string AccountId { get; set; }
        public string AccountType { get; set; }
        public Customer Customer { get; set; }
        public double Balance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}

using BSynchro.DataAccess.Abstraction.Models;
using System.Collections.Generic;

namespace BSynchro.DataAccess.Models
{
    public class Customer : BaseEntity
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

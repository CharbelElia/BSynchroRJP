using System.Collections.Generic;

namespace BSynchro.Dto
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; }
        public List<TransactionDto> Transactions { get; set; }
    }
}

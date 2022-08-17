using BSynchro.DataAccess.Models;
using BSynchro.Dto;
using System.Threading.Tasks;

namespace BSynchro.Service.Abstraction
{
    public interface ICustomersService
    {
        public Task<CustomerDto> GetCustomerInfoAsync (string customerId);
        public Task<Customer> GetCustomerAsync(string customerId);
    }
}

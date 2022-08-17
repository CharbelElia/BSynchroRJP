using BSynchro.DataAccess.Models;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.Dto;
using BSynchro.Helpers.Exceptions;
using BSynchro.Helpers.Mapper;
using BSynchro.Service.Abstraction;
using BSynchro.Service.Abstraction.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSynchro.Service
{
    public class CustomersService : BaseService<CustomersService>, ICustomersService
    {
        public CustomersService(IUnitOfWork uow, IBSynchroMapper mapper, ILogger<CustomersService> logger) : base(uow, mapper, logger)
        {
        }
        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            var customer = await this._uow.GetRepository<Customer>().GetAll().Where(c => c.CustomerId == customerId)
                .Include(c=>c.Accounts)
                .FirstOrDefaultAsync();
            if (customer == null)
                throw new BSynchroBaseException(
                    BSynchroServicesExceptionConstants.EX_CODE_CUSTOMER_NOT_FOUND,
                    BSynchroServicesExceptionConstants.EX_MSG_CUSTOMER_NOT_FOUND);
            return customer;
        }
        public async Task<CustomerDto> GetCustomerInfoAsync(string customerId)
        {
            var customer = await GetCustomerAsync(customerId);
            CustomerDto customerDto = this._mapper.Map<CustomerDto>(customer);
            customerDto.Balance = customer.Accounts.Sum(acc => acc.Balance);
            var transactions = await this._uow.GetRepository<Transaction>().GetAll()
                .Include(t => t.Account)
                .ThenInclude(acc => acc.Customer)
                .Where(t => t.Account.Customer.CustomerId == customerId).ToListAsync();
            customerDto.Transactions = this._mapper.Map<List<TransactionDto>>(transactions);
            return customerDto;
        }
        
    }
}


using BSynchro.DataAccess.Models;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.Dto;
using BSynchro.Helpers.Mapper;
using BSynchro.Service.Abstraction;
using BSynchro.Service.Abstraction.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BSynchro.Service
{
    public class AccountsService : BaseService<AccountsService>, IAccountsService
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ICustomersService _customersService;
        public AccountsService(IUnitOfWork uow, IBSynchroMapper mapper, ILogger<AccountsService> logger, 
            ITransactionsService transactionsService,
            ICustomersService customersService) : base(uow, mapper, logger)
        {
            _transactionsService = transactionsService;
            _customersService = customersService;
        }

        public async Task<AccountDto> CreateNewAccountAsync(UserInfoDto userInfoDto)
        {
            var customer = await this._customersService.GetCustomerAsync(userInfoDto.CustomerId);
            // set all customer's accounts to savings account, in order to create a new "current account"
            // considering that a customer can have one and only one current account
            //var customerAccounts = await this._uow.GetRepository<Account>().GetAll()
            //    .Include(acc => acc.Customer).Where(acc => acc.Customer.CustomerId == customer.CustomerId).ToListAsync();
            customer.Accounts.ToList().ForEach(acc => acc.AccountType = AccountType.SavingsAccount.ToString());
            // create new account
            Account account = new Account()
            {
                AccountId = Guid.NewGuid().ToString(),
                AccountType = AccountType.CurrentAccount.ToString(),
                Balance = userInfoDto.InitialCredit,
                Customer = customer
            };
            await this._uow.GetRepository<Account>().AddAsync(account);
            if (userInfoDto.InitialCredit != 0)
            {
                // call the transactions service to add new transaction
                await _transactionsService.CreateNewTransactionAsync(account, TransactionType.Deposit, userInfoDto.InitialCredit);
            }
            await this._uow.SaveChangesAsync();
            return this._mapper.Map<AccountDto>(account);
        }
    }
}

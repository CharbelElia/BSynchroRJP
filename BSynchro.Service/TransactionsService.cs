
using BSynchro.DataAccess.Models;
using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.Helpers.Mapper;
using BSynchro.Service.Abstraction;
using BSynchro.Service.Abstraction.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BSynchro.Service
{
    public class TransactionsService : BaseService<TransactionsService>, ITransactionsService
    {
        public TransactionsService(IUnitOfWork uow, IBSynchroMapper mapper, ILogger<TransactionsService> logger) : base(uow, mapper, logger)
        {
        }

        public async Task CreateNewTransactionAsync(Account account, TransactionType transactionType, double amount)
        {
            Transaction transaction = new Transaction()
            {
                Account = account,
                Amount = amount,
                TransactionId = Guid.NewGuid().ToString(),
                TransactionType = transactionType.ToString(),
            };
            await this._uow.GetRepository<Transaction>().AddAsync(transaction);
        }
    }
}

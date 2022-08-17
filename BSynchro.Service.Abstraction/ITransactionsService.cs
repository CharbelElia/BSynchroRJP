
using BSynchro.DataAccess.Models;
using BSynchro.Service.Abstraction.Enums;
using System.Threading.Tasks;

namespace BSynchro.Service.Abstraction
{
    public interface ITransactionsService
    {
        Task CreateNewTransactionAsync(Account account, TransactionType transactionType, double amount);
    }
}


using BSynchro.Dto;
using System.Threading.Tasks;

namespace BSynchro.Service.Abstraction
{
    public interface IAccountsService
    {
        Task<AccountDto> CreateNewAccountAsync(UserInfoDto userInfoDto);
    }
}

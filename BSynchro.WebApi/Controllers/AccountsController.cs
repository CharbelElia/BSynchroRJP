using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BSynchro.Service.Abstraction;
using BSynchro.Dto;

namespace BSynchro.WebApi.Controllers
{
    /// <summary>
    /// controller for accounts resource
    /// </summary>
    public class AccountsController : CoreBaseController<AccountsController>
    {
        private readonly IAccountsService _accountsService;
        /// <summary>
        /// controller constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="accountsService"></param>
        public AccountsController(ILogger<AccountsController> logger,
            IAccountsService accountsService) :
            base(logger)
        {
            _accountsService = accountsService;
        }

        /// <summary>
        /// This endpoint is to create a "new current" account for an existing customer
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(AccountDto))]
        [HttpPost]
        public async Task<IActionResult> CreateCurrentAccountAsync([FromBody] UserInfoDto userInfoDto)
        {
            var res = await _accountsService.CreateNewAccountAsync(userInfoDto);
            return Created("/"+res.AccountId, res);
        }
    }
}
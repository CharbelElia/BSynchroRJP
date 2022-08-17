using BSynchro.Dto;
using BSynchro.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace BSynchro.WebApi.Controllers
{
    public class CustomersController : CoreBaseController<CustomersController>
    {
        private readonly ICustomersService _customersService;
        /// <summary>
        /// controller constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="customersService"></param>
        public CustomersController(ILogger<CustomersController> logger,
        ICustomersService customersService) :
        base(logger)
    {
            _customersService = customersService;
    }

    /// <summary>
    /// This endpoint is to get customer details
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CustomerDto))]
    [HttpGet("{customerId}")]
    public async Task<IActionResult> CreateCurrentAccountAsync(string customerId)
    {
        var customer = await _customersService.GetCustomerInfoAsync(customerId);
        return Ok(customer);
    }
}
}

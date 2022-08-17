using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BSynchro.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoreBaseController<T>: Controller
    {
        protected readonly ILogger<T> _logger;

        public CoreBaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
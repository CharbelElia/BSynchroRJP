using BSynchro.DataAccess.RelationalDb.Abstraction;
using BSynchro.Helpers.Mapper;
using Microsoft.Extensions.Logging;

namespace BSynchro.Service
{
    public class BaseService<T>
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IBSynchroMapper _mapper;
        protected readonly ILogger<T> _logger;

        public BaseService(IUnitOfWork uow, IBSynchroMapper mapper, ILogger<T> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }
    }
}

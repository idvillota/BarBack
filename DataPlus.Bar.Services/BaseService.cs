using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;

namespace DataPlus.Bar.Services
{
    public class BaseService
    {
        internal ILoggerManager _logger;
        internal IWrapperRepository _wrapperRepository;

        public BaseService(IWrapperRepository wrapperRepository, ILoggerManager logger)
        {
            _wrapperRepository = wrapperRepository;
            _logger = logger;
        }
    }
}

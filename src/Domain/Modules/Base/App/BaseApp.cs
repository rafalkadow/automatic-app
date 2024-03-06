using AutoMapper;
using Domain.Interfaces;

namespace Domain.Modules.Base.App
{
    public abstract class BaseApp
    {
        public static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IDbContext DbContext { get; set; }
        public IMapper Mapper { get; set; }
        public IUserAccessor UserAccessor { get; set; }
    }
}

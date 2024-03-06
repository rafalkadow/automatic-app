using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Base.App;

namespace Application.Modules.Base.Queries
{
    [Serializable]
    public class BaseQueryHandler : BaseApp, IBaseQueryUtility
    {
        public BaseQueryHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
        {
            DbContext = dbContext;
            Mapper = mapper;
            UserAccessor = userAccessor;
        }
    }
}
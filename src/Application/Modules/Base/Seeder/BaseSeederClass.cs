using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.Base.App;

namespace Application.Modules.Base.Seeder
{
    [Serializable]
	public class BaseSeederClass : BaseApp
    {
        public BaseSeederClass(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
		{
			this.DbContext = dbContext;
			this.Mapper = mapper;
			this.UserAccessor = userAccessor;
        }
	}

}
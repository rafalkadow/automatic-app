using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.SignIn.Commands;
using Shared.Models;
using Application.Seeder;
using Shared.Extensions.GeneralExtensions;
using MediatR;
using Application.Modules.Base.Commands;
using Domain.Modules.PlcParameter.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Modules.Identity;

namespace Application.Modules.SignIn.Commands
{
    [Serializable]
    public class SignInHandler : BaseCommandHandler, IRequestHandler<SignInCommand, OperationResult>
    {
        public SignInHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }

        public async Task<OperationResult> Handle(SignInCommand command, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{command.RenderProperties()}', cancellationToken='{cancellationToken}')");
            try
            {
                await new DataSeeder().SeedDataOnApplication(DbContext, Mapper, UserAccessor, logger);
                var accountFind = await DbContext.GetQueryable<User>().FirstOrDefaultAsync(x => x.Email == command.SignInEmail);
                if (accountFind == null || accountFind.Id == Guid.Empty)
                {
                    return new OperationResult(false);
                }
                var messageUrl = "";

                return new OperationResult(accountFind.Id) { Message = messageUrl };
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
				throw;
			}
        }
    }
}
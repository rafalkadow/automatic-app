using Domain.Interfaces;
using Domain.Modules.Error.Consts;
using Domain.Modules.Error.Queries;
using AutoMapper;
using Shared.Extensions.GeneralExtensions;
using Application.Modules.Base.Queries;
using MediatR;

namespace Application.Modules.Error.Queries
{
    [Serializable]
    public class GetErrorQueryByIdHandler : BaseQueryHandler, IRequestHandler<GetErrorQueryById, GetErrorResultById>
    {
        public GetErrorQueryByIdHandler(IDbContext dbContext, IMapper mapper, IUserAccessor userAccessor)
            : base(dbContext, mapper, userAccessor)
        {
        }
        public async Task<GetErrorResultById> Handle(GetErrorQueryById filter, CancellationToken cancellationToken)
        {
            logger.Info($"Handle(filter='{filter.RenderProperties()}', cancellationToken='{cancellationToken}')");
            GetErrorResultById? model = null;
            try
            {
                switch (filter.ErrorCode)
                {
                    case ErrorConsts.Error400:
                        model = Error400();
                        break;

                    case ErrorConsts.Error401:
                        model = Error401(filter.ErrorUrl);
                        break;

                    case ErrorConsts.Error404:
                        model = Error404(filter.UrlReturn, filter.ErrorUrl);
                        break;

                    case ErrorConsts.Error500:
                        model = Error500(filter.ErrorUrl);
                        break;

                    default:
                        model = Error500();
                        break;
                }
                return model;
            }
            catch (Exception ex)
            {
                logger.Error($"Handle(ex='{ex.ToString()}')");
                throw;
            }
        }

        private GetErrorResultById Error400()
        {
            var model = new GetErrorResultById
            {
                ErrorCode = ErrorConsts.Error400,
                ErrorName = "Bad Request",
                ErrorDescription = "Invalid query – the request cannot be handled by the server due to an abnormality perceived as user error (e.g. incorrect query syntax)."
            };
            return model;
        }

        private GetErrorResultById Error401(string errorUrl)
        {
            var model = new GetErrorResultById
            {
                ErrorCode = ErrorConsts.Error401,
                ErrorName = "Unauthorized",
                ErrorDescription = "Unauthorized access – A request for a resource that requires authentication.",
                ErrorUrl = errorUrl,
            };
            return model;
        }

        private GetErrorResultById Error404(string urlReturn, string errorUrl)
        {
            var model = new GetErrorResultById
            {
                ErrorCode = ErrorConsts.Error404,
                ErrorName = "Not Found",
                ErrorDescription = "Not found - the server did not find the resource according to the given URL or anything that would indicate the existence of such a resource in the past.",
                UrlReturn = urlReturn,
                ErrorUrl = errorUrl,
            };
            return model;
        }

        private GetErrorResultById Error500(string? errorUrl = null)
        {
            var model = new GetErrorResultById
            {
                ErrorCode = ErrorConsts.Error500,
                ErrorName = "Internal Server Error",
                ErrorDescription = "Internal server error - The server encountered unexpected difficulties that prevented the request from being completed.",
                ErrorUrl = errorUrl,
            };
            return model;
        }
    }
}
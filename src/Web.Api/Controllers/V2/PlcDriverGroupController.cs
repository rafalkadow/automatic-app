using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers.V2
{
    //[Authorize]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlcDriverGroupController : BaseApiController
    {
        private readonly ILogger<PlcDriverGroupController> logger;

        public PlcDriverGroupController(
            ILogger<PlcDriverGroupController> logger,
            IMediator mediator,
            IMapper mapper,
            IDbContext dbContext)
            : base(mediator, mapper, dbContext)
        {
            this.logger = logger;
        }

    }
}

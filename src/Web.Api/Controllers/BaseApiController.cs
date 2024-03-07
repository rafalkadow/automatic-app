using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public IMapper mapper { get; set; }
        public IDbContext dbContext { get; set; }
        protected IMediator mediator { get; set; }

        public BaseApiController(IMediator mediator, IMapper mapper, IDbContext dbContext)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.dbContext = dbContext;
        }
    }
}

using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    //[ApiController]
    //[Route("api/v1/[controller]")]
    //public class BaseApiController : ControllerBase
    //{
    //    public IMapper mapper { get; set; }
    //    public IDbContext dbContext { get; set; }
    //    protected IMediator mediator { get; set; }

    //    public BaseApiController(IMediator mediator, IMapper mapper, IDbContext dbContext)
    //    {
    //        this.mediator = mediator;
    //        this.mapper = mapper;
    //        this.dbContext = dbContext;
    //    }
    //}

    /// <summary>
    /// Abstract BaseApi Controller Class
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {
        private IMediator _mediatorInstance;
        private ILogger<T> _loggerInstance;
        protected IMediator mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> _logger => _loggerInstance ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}

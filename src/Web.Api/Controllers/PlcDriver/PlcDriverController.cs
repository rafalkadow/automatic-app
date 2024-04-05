using System.Net;
using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriver.Commands;
using Domain.Modules.PlcDriver.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Exceptions;

namespace Web.Api.Controllers.V1
{
    [Authorize]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlcDriverController : BaseApiController<PlcDriverController>
    {
        private readonly ILogger<PlcDriverController> logger;

        //public PlcDriverController(
        //    ILogger<PlcDriverController> logger,
        //    IMediator mediator,
        //    IMapper mapper,
        //    IDbContext dbContext)
        //    : base(mediator, mapper, dbContext)
        //{
        //    this.logger = logger;
        //}

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPlcDriverResultAll>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetPlcDriverQueryAll();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreatePlcDriverCommand command)
        {
            try
            {
                var response = await mediator.Send(command);
                return StatusCode((int)HttpStatusCode.Created, response);
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GetPlcDriverResultById), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = new GetPlcDriverQueryById(id);
                var response = await mediator.Send(query);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }


    }
}

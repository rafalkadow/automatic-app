using System.Net;
using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.PlcDriverGroup.Commands;
using Domain.Modules.PlcDriverGroup.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Exceptions;

namespace Web.Api.Controllers.V1
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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetPlcDriverGroupResultAll>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetPlcDriverGroupQueryAll();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreatePlcDriverGroupCommand command)
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
        [ProducesResponseType(typeof(GetPlcDriverGroupResultById), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = new GetPlcDriverGroupQueryById(id);
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

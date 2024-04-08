using System.Net;
using AutoMapper;
using Domain.Interfaces;
using Domain.Modules.DictionaryOfParameterCategory.Commands;
using Domain.Modules.DictionaryOfParameterCategory.Queries;
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
    public class DictionaryOfParameterCategoryController : BaseApiController<DictionaryOfParameterCategoryController>
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetDictionaryOfParameterCategoryResultAll>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var query = new GetDictionaryOfParameterCategoryQueryAll();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CreateDictionaryOfParameterCategoryCommand command)
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
        [ProducesResponseType(typeof(GetDictionaryOfParameterCategoryResultById), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var query = new GetDictionaryOfParameterCategoryQueryById(id);
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

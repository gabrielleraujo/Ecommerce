using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Ecommerce.CrossCutting.DTO.Size;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.Validation.Exceptions;
using Ecommerce.API.Commons.Responses;
using System;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/size")]
    public class SizeController : ControllerBase
    {
        private readonly ISizeApplicationService _sizeApplicationService;

        public SizeController(ISizeApplicationService sizeApplicationService)
        {
            _sizeApplicationService = sizeApplicationService;
        }

        /// <summary>
        /// Creates a size.
        /// </summary>
        /// <param name="createSizeDto"></param>
        /// <returns>A newly created size</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "nome": "PP"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly size</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a size")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadSizeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult Add([FromBody] CreateSizeDTO createSizeDto)
        {
            try
            {
                var readDto = _sizeApplicationService.Add(createSizeDto);
                return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationErrorResponse.From(e));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpGet]
        [SwaggerOperation(Summary = "List all sizes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadSizeDTO>))]
        public IActionResult List()
        {
            var readDto = _sizeApplicationService.List();

            if (readDto != null) { return Ok(readDto); }

            return NotFound();
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a size by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadSizeDTO))]
        public IActionResult GetById(int id)
        {
            var readDto = _sizeApplicationService.GetById(id);

            if (readDto != null) { return Ok(readDto); }

            return NotFound();
        }
    }
}
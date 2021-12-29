using Ecommerce.CrossCutting.DTO.Color;
using Ecommerce.Ioc.Common;
using Ecommerce.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/color")]
    public class ColorController : ControllerBase
    {
        private readonly IColorApplicationService _colorApplicationService;

        public ColorController(IColorApplicationService colorApplicationService)
        {
            _colorApplicationService = colorApplicationService;
        }

        /// <summary>
        /// Creates a color.
        /// </summary>
        /// <param name="createColorDto"></param>
        /// <returns>A newly created color</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "nome": "blue"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly color</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a color")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadColorDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public IActionResult Add([FromBody] CreateColorDTO createColorDto)
        {
            var readDto = _colorApplicationService.Add(createColorDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "List all colors")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadColorDTO>))]
        public IActionResult List()
        {
            var readDto = _colorApplicationService.List();
            return Ok(readDto);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a color by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadColorDTO))]
        public IActionResult GetById(int id)
        {
            var readDto = _colorApplicationService.GetById(id);

            if (readDto != null) { return Ok(readDto); }

            return NotFound();
        }
    }
}
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using FluentResults;
using Ecommerce.Ioc.Common;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.CrossCutting.DTO.Category;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplicationService _categoryApplicationService;

        public CategoryController(ICategoryApplicationService categoryApplicationService)
        {
             _categoryApplicationService = categoryApplicationService;
        }

        /// <summary>
        /// Creates a category.
        /// </summary>
        /// <param name="createCategoryDto"></param>
        /// <returns>A newly created category</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "nome": "blusa"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly category</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a category")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadCategoryDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public IActionResult Add([FromBody] CreateCategoryDTO createCategoryDto)
        {
            var readDto = _categoryApplicationService.Add(createCategoryDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }


        [HttpGet]
        [SwaggerOperation("List all categories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadCategoryDTO>))]
        public IActionResult List()
        {
            var readDto = _categoryApplicationService.List();
            return Ok(readDto);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a category by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadCategoryDTO))]
        public IActionResult GetById(int id)
        {
            var readDto = _categoryApplicationService.GetById(id);

            if (readDto != null) { return Ok(readDto); }

            return NotFound();
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a category by id")]
        public IActionResult Delete(int id)
        {
            Result result = _categoryApplicationService.Delete(id);

            if (result.IsFailed) { return NotFound(result.Errors.First().Message); }

            return NoContent();
        }


        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a category by id")]
        public IActionResult Update(int id, [FromBody] UpdateCategoryDTO categoryDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Result result = _categoryApplicationService.Update(id, categoryDto);

            if (result.IsFailed) { return NotFound(result.Errors.First().Message); }

            return NoContent();
        }
    }
}
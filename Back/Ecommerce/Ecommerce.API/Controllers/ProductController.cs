using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using Swashbuckle.AspNetCore.Annotations;
using Ecommerce.CrossCutting.DTO.Product;
using Ecommerce.ApplicationService.Interfaces;
using System.Collections.Generic;
using Ecommerce.Ioc.Common;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <param name="createProductDto"></param>
        /// <returns>A newly created product</returns>
        /// 
        /// <response code="201">Returns the newly product</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a product")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public IActionResult Add([FromBody] CreateProductDTO createProductDto)
        {
            var readDto = _productApplicationService.Add(createProductDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }

        
        [HttpGet]
        [SwaggerOperation(Summary = "List all products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadProductDTO>))]
        public IActionResult List()
        {
            var readDto = _productApplicationService.List();
            return Ok(readDto);
        }

        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a product by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadProductDTO))]
        public IActionResult GetById(int id)
        {
            var readDto = _productApplicationService.GetById(id);

            if (readDto != null) return Ok(readDto);

            return NotFound();
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a product by id")]
        public IActionResult Delete(int id)
        {
            Result result = _productApplicationService.Delete(id);

            if (result.IsFailed) return NotFound(result.Errors.First().Message);

            return NoContent();
        }


        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a product by id")]
        public IActionResult Update(int id, [FromBody] UpdateProductDTO produtoDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
                
            Result result = _productApplicationService.Update(id, produtoDto);

            if (result.IsFailed) { return NotFound(result.Errors.First().Message); }

            return NoContent();
        }
    }
}
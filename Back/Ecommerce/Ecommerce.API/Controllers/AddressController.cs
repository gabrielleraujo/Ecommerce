using Ecommerce.CrossCutting.DTO.Address;
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
    [Route("api/v{version:apiVersion}/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressApplicationService _addressApplicationService;

        public AddressController(IAddressApplicationService addressApplicationService)
        {
            _addressApplicationService = addressApplicationService;
        }

        /// <summary>
        /// Creates a adsress.
        /// </summary>
        /// <param name="createAddressDto"></param>
        /// <returns>A newly created adsress</returns>
        /// 
        /// <response code="201">Returns the newly adsress</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a address")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadAddressDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public IActionResult Add([FromBody] CreateAddressDTO createAddressDto)
        {
            var readDto = _addressApplicationService.Add(createAddressDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "List all addresses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadAddressDTO>))]
        public IActionResult List()
        {
            var readDto = _addressApplicationService.List();
            return Ok(readDto);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a address by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadAddressDTO))]
        public IActionResult GetById(int id)
        {
            var readDto = _addressApplicationService.GetById(id);

            if (readDto != null) { return Ok(readDto); }

            return NotFound();
        }
    }
}
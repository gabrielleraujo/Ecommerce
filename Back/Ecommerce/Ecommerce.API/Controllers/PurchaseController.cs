using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Ecommerce.API.Commons.Responses;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.CrossCutting.DTO.Purchase;
using Ecommerce.Validation.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseApplicationService _purchaseApplicationService;
        
        public PurchaseController(
            IPurchaseApplicationService purchaseApplicationService)
        {
            _purchaseApplicationService = purchaseApplicationService;
        }

        /// <summary>
        /// Creates a purchase.
        /// </summary>
        /// <param name="createPurchaseDto"></param>
        /// <returns>A newly created purchase</returns>
        /// 
        /// <response code="201">Returns the newly purchase</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Make purchase")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadPurchaseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public IActionResult MakePurchase(CreatePurchaseDTO createPurchaseDto)
        {
            try
            {
                var readDto = _purchaseApplicationService.Add(createPurchaseDto);
                return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
            }
            catch (ValidationException e)
            {
                return BadRequest(ValidationErrorResponse.From(e));
            }
            catch(ArgumentException e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpGet("get-has-no-summary")]
        [SwaggerOperation(Summary = "Lists all purchases that do not yet have a Summary.")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadPurchaseDTO>))]
        public IActionResult GetHasNoSummary()
        {
            var readDto = _purchaseApplicationService.GetHasNoSummary();
            return Ok(readDto);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "List all purchases")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadPurchaseDTO>))]
        public IActionResult List()
        {
            var readDto = _purchaseApplicationService.List();
            return Ok(readDto);
        }


        [HttpGet("list-user-purchases/{userId:int}")]
        [SwaggerOperation(Summary = "List all user purchases by userId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadPurchaseDTO>))]
        public IActionResult ListUserPurchases([FromRoute] int userId)
        {
            var readDto = _purchaseApplicationService.ListUserPurchases(userId);
            return Ok(readDto);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a purchase by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadPurchaseDTO))]
        public IActionResult GetById([FromRoute] int id)
        {
            var readDto = _purchaseApplicationService.GetById(id);

            if (readDto != null) { return Ok(readDto); }

            return NotFound();
        }
    }
}
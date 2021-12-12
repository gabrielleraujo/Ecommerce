using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.CrossCutting.DTO.Purchase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/purchase-summary")]
    public class PurchaseSummaryController : ControllerBase
    {
        private readonly IPurchaseSummaryApplicationService _purchaseSummaryApplicationService;

        public PurchaseSummaryController(IPurchaseSummaryApplicationService purchaseSummaryApplicationService)
        {
            _purchaseSummaryApplicationService = purchaseSummaryApplicationService;
        }


        [HttpGet("build")]
        [SwaggerOperation(Summary = "Used by Job to make the purchase summary")]
        public IActionResult Build()
        {
            var result = _purchaseSummaryApplicationService.Build();

            if (result.IsFailed) { return NotFound(new { message = result.Reasons[0] }); }
            return Ok();
        }


        [HttpGet("{data}")]
        [SwaggerOperation(Summary = "Search the purchase summary based on purchase date")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadPurchaseSummaryDTO))]
        public IActionResult GetByDate([FromRoute] DateTime date)
        {
            var readDto = _purchaseSummaryApplicationService.GetById(date);

            if (readDto == null) { return NotFound(); }

            return Ok(readDto);
        }


        [HttpGet()]
        [SwaggerOperation(Summary = "Lists all purchase summary records")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadPurchaseSummaryDTO>))]
        public IActionResult ListByDate()
        {
            var readDto = _purchaseSummaryApplicationService.ListByDate();
            return Ok(readDto);
        }
    }
}
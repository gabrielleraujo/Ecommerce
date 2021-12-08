using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.CrossCutting.DTO.User;
using Microsoft.AspNetCore.Http;
using Ecommerce.ApplicationService;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationApplicationService _authenticationApplicationService;

        public AuthenticationController(
            IAuthenticationApplicationService authenticationApplicationService)
        {
            _authenticationApplicationService = authenticationApplicationService;
        }

        /// <summary>
        /// Login.
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns>A newly created token</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "username": "jao",
        ///        "password": "123"
        ///     }
        ///
        /// </remarks>
        /// <response code="400">If the item is null</response>
        /// <response code="401">If were unable to authenticate you</response>
        /// <response code="200">Returns the newly token</response>
        [SwaggerOperation(Summary = "Authenticates a user and responds with the generated token")]
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult Autenticate([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var result = _authenticationApplicationService.CreateToken(loginDto);

            if (result.IsFailed) { return Unauthorized(result.Errors); }

            return Ok(result.Value);
        }
    }
}
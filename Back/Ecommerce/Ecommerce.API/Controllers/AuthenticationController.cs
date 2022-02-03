using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.CrossCutting.DTO.User;
using Microsoft.AspNetCore.Http;
using Ecommerce.Authentication;
using Ecommerce.Ioc.Common;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationApplicationService _authentication;

        public AuthenticationController(IAuthenticationApplicationService authentication)
        {
            _authentication = authentication;
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
        ///        "username": "gabi",
        ///        "password": "123"
        ///     }
        ///
        /// </remarks>
        /// <response code="400">If the item is null</response>
        /// <response code="401">If were unable to authenticate you</response>
        /// <response code="200">Returns the newly token</response>
        [SwaggerOperation(Summary = "Authenticates a user and responds with the generated token")]
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<IActionResult> Autenticate([FromBody] LoginDTO loginDto)
        {
            var result = await _authentication.CreateToken(loginDto);
            return result.IsFailed ? Unauthorized(result.Errors) : Ok(result.Value);
        }
    }
}
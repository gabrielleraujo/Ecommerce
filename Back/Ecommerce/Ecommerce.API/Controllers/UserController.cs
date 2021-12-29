using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Ecommerce.ApplicationService.Interfaces;
using Ecommerce.CrossCutting.DTO.User;
using System.Collections.Generic;
using Ecommerce.Ioc.Common;

namespace Ecommerce.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userApplicationService;

        public UserController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        /// <summary>
        /// Creates a user.
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns>A newly created user</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "name": "João",
        ///        "surmane": Souza,
        ///        "email": joao@gmail.com,
        ///        "username": "jao",
        ///        "password": 123,
        ///        "repassword": 123,
        ///        "role": "comprador",
        ///        "adressId": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly user</response>
        /// <response code="400">If the item is null</response>
        /// <response code="500">If an internal server error occurred</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Add a user")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReadUserDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(InternalServerErrorResponse))]
        public IActionResult Adicionar([FromBody] CreateUserDTO createUserDto)
        {
            var readDto = _userApplicationService.Add(createUserDto);
            return CreatedAtAction(nameof(GetById), new { id = readDto.Id }, readDto);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "List all users")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ReadUserDTO>))]
        public IActionResult List()
        {
            var readDto = _userApplicationService.List();
            return Ok(readDto);
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Search a user by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReadUserDTO))]
        public IActionResult GetById(int id)
        {
            var readDto = _userApplicationService.GetById(id);

            if (readDto != null) { return Ok(readDto); }
            
            return NotFound();
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a user by id")]
        public IActionResult Delete(int id)
        {
            Result result = _userApplicationService.Delete(id);

            if (result.IsFailed) { return NotFound(result.Reasons[0]); }
            
            return NoContent();
        }


        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a user by id")]
        public IActionResult Update(int id, [FromBody] UpdateUserDTO usuarioDto)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            Result result = _userApplicationService.Update(id, usuarioDto);

            if (result.IsFailed) { return NotFound(); }
                
            return NoContent();
        }
    }
}
using GrindRailsAPI.Services.Interfaces;
using GrindRailsAPI.Shared.DTOs.User;
using GrindRailsAPI.Shared.ModelsView.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GrindRailsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IIdentityServices _identityService;

        public AuthenticationController(IIdentityServices identityService) =>
            _identityService = identityService;

        /// <summary>
        /// Login do usuário via usuário/senha.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="userLoginViewModel">Dados de login do usuário</param>
        /// <returns></returns>
        /// <response code="200">Login realizado com sucesso</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="401">Erro caso usuário não esteja autorizado</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<ActionResult<UserLoginResponse>> Login(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.Login(userLoginViewModel);
            if (resultado.Sucesso)
                return Ok(resultado);

            return Unauthorized();
        }

        /// <summary>
        /// Login do usuário via refresh token.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns></returns>
        /// <response code="200">Login realizado com sucesso</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="401">Erro caso usuário não esteja autorizado</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(UserLoginResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpPost("refresh-login")]
        public async Task<ActionResult<UserLoginResponse>> RefreshLogin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return BadRequest();

            var resultado = await _identityService.LoginNoPassword(userId);
            if (resultado.Sucesso)
                return Ok(resultado);

            return Unauthorized();
        }
    }
}

using GrindRailsAPI.Identity.Services;
using GrindRailsAPI.Services.Interfaces;
using GrindRailsAPI.Shared.DTOs;
using GrindRailsAPI.Shared.ModelsView.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GrindRailsAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IIdentityServices _identityService;

        public UserController(IIdentityServices identityService) =>
            _identityService = identityService;

        /// <summary>
        /// Cadastro de usuário.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param name="userCreateViewModel">Dados de cadastro do usuário</param>
        /// <returns></returns>
        /// <response code="200">Usuário criado com sucesso</response>
        /// <response code="400">Retorna erros de validação</response>
        /// <response code="500">Retorna erros caso ocorram</response>
        [ProducesResponseType(typeof(UserCreateViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Authorize]
        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastrar(UserCreateViewModel userCreateViewModel)
        {
            ServiceResponseDTO<UserViewModel> serviceResponseDTO = await _identityService.CreateUser(userCreateViewModel);

            return StatusCode(serviceResponseDTO.StatusCode, serviceResponseDTO);
        }

    }
}

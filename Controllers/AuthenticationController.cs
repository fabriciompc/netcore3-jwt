using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Repositories;
using Shop.Representation;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("v1/api")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null) return NotFound(new { message = "Usuário ou Senha Inválidos!" });

            var token = TokenService.GenerateToken(user);

            var userRepresentation = UserRepresentation.CreateRepresentation(user);

            return new
            {
                userRepresentation,
                token
            };
        }
    }
}
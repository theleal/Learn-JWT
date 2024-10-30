using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JWT.Models;
using JWT.Repositories;
using JWT.Services;

namespace JWT.Controllers
{
    [Route("v1/account")]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);

            if(user == null)
            {
                return NotFound("Usuario não encontrado");
            }

            var token = TokenService.GenerateToken(user);
            user.Password = string.Empty;

            return new
            {
                user = user,
                token = token,
            };
        }

        [HttpGet]
        [Route("Anonimo")]
        [AllowAnonymous]

        public string Anonimo() => "Rota sem autenticacao";

        [HttpGet]
        [Route("Autenticado")]
        [Authorize]

        public string Autenticado() => User.Identity.Name?.ToString();

        [HttpGet]
        [Route("Employee")]
        [Authorize(Roles = "Admin,User")]

        public string Employee() => "Funcionario";


        [HttpGet]
        [Route("Admin")]
        [Authorize(Roles = "Admin")]

        public string Admin() => "Admin";


    }
}

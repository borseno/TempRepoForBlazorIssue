using Microsoft.AspNetCore.Mvc;
using Votings.Shared;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel loginModel)
            => Ok(await loginService.Login(loginModel));
    }
}

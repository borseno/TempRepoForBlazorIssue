using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer
{

    [Route("[controller]")]
    [ApiController]
    public class EmailConfirmationController : ControllerBase
    {
        private readonly IEmailConfirmationService service;

        public EmailConfirmationController(IEmailConfirmationService service)
        {
            this.service = service;
        }

        [Route(nameof(Confirm))]
        [HttpGet]
        public async Task<IActionResult> Confirm(string userId, string token)
        {
            var result = await service.Confirm(userId, token);

            if (result.Successful)
            {
                return Redirect("/login");
            }
            else
            {
                return Redirect("/confirmationError");
            }
        }

    }
}

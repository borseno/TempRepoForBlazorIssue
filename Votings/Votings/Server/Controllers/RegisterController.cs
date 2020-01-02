using Microsoft.AspNetCore.Mvc;
using Votings.Shared;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer
{
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterUserService _service;
        private readonly IEmailSendingService _emailSender;

        public RegisterController(IRegisterUserService service, IEmailSendingService emailSender)
        {
            _service = service;
            _emailSender = emailSender;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterModel model)
        {
            var result = await _service.RegisterUser(model);

            if (result.Successful)
            {
                var url = Url.Action(
                    "Confirm",
                    "EmailConfirmation",
                    new { userId = result.UserId, result.Token },
                    protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(result.UserEmail, "Password confirmation",
                    "Confirm your password by visiting the following link: " + url
                    );
            }

            return Ok(result);
        }
    }
}

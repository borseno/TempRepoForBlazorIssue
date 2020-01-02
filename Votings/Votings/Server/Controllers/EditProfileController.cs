using Microsoft.AspNetCore.Mvc;
using Votings.Shared;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;

namespace Votings.Server.BusinessLayer
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditProfileController : ControllerBase
    {
        private readonly IEditProfileService service;

        public EditProfileController(IEditProfileService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> Edit(ProfileModel model)
        {
            var currentUserEmail = User.Identity.Name;

            if (currentUserEmail != model.Email)
            {
                return Forbid("your actual email is different from data you sent");
            }

            return Ok(await service.EditUser(model));
        }
    }
}

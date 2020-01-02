using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Votings.Server.BusinessLayer.Services.Interfaces;
using Votings.Shared;
using Votings.Shared.PageModels;

namespace Votings.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingsController : ControllerBase
    {
        private readonly IVotingsService service;

        public VotingsController(IVotingsService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public Task<IActionResult> Register(VotingInitialInfoModel model)
            => LaunchServiceWithUserId(model, service.Register);

        [HttpPost]
        [Route("[action]")]
        public Task<IActionResult> Edit(VotingEditModel model)
            => LaunchServiceWithUserId(model, service.Edit);

        [HttpGet]
        [Route("[action]/{id}")]
        public Task<IActionResult> State(int id)
            => LaunchServiceWithUserId(id, service.GetVotingStateAsync);

        [HttpGet]
        [Route("[action]/{id}")]
        public Task<IActionResult> EditModel(int id)
            => LaunchServiceWithUserId(id, service.GetVotingEditModel);

        [HttpGet]
        [Route("[action]/{currentUserOnly}")]
        public Task<IActionResult> References(bool currentUserOnly)
            => LaunchServiceWithUserId(currentUserOnly, service.GetVotingsReferencesAsync);

        private async Task<IActionResult> LaunchServiceWithUserId<TArg, TResult>(TArg arg, Func<TArg, string, Task<TResult>> func)
        {
            var userId = User.Claims.First(i => i.Type == CustomClaimTypes.UserId).Value;

            var result = await func(arg, userId);

            return Ok(result);
        }
    }
}

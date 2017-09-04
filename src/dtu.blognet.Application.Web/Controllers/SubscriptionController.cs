using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.CommentCommands;
using dtu.blognet.Core.Command.Commands.SubscriptionCommands;
using dtu.blognet.Core.Command.InputModels.CommentInputModels;
using dtu.blognet.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Account> _userManager;

        public SubscriptionController(IMapper mapper, UserManager<Account> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        
        
        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> Supscribe([FromServices] SubscriptionCommandHandlerFactory commandHandlerFactory, AddSubscriptionCommand command)
        {
            command.AccountId = _userManager.GetUserId(User);
            var handler = commandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }
        
        [Authorize]
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> Info([FromServices])
        {
            return Ok();
        }
        
        
    }
}
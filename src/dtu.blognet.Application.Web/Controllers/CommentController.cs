﻿using System.Threading.Tasks;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using Microsoft.AspNetCore.Mvc;
using dtu.blognet.Core.Command.InputModels.CommentInputModels;
using dtu.blognet.Core.Command.Commands.CommentCommands;
using dtu.blognet.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace dtu.blognet.Application.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<Account> _userManager;

        public CommentController(UserManager<Account> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CommentCommandHandlerFactory commentCommandHandlerFactory, [FromBody]CommentInputModel model)
        {
            model.CreaterId = _userManager.GetUserId(User);
            var command = new AddCommentAsyncCommand { Model = model };
            var handler = commentCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }
        
    }
}

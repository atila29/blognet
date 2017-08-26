using System.Threading.Tasks;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using Microsoft.AspNetCore.Mvc;
using dtu.blognet.Core.Command.InputModels.CommentInputModels;
using dtu.blognet.Core.Command.Commands.CommentCommands;

namespace dtu.blognet.Application.Web.Controllers
{
    public class CommentController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromServices] CommentCommandHandlerFactory commentCommandHandlerFactory, CommentInputModel model)
        {
            var command = new AddCommentAsyncCommand { Model = model };
            var handler = commentCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }
    }
}

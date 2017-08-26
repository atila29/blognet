using System.Threading.Tasks;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class PostController : Controller
    {
        public PostController()
        {
            
        }

        public async Task<IActionResult> CreatePost([FromServices] PostCommandHandlerFactory postCommandHandlerFactory, PostInputModel model)
        {
            var command = new AddPostAsyncCommand {Model = model};
            var handler = postCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }
    }
}
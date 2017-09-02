using System.Threading.Tasks;
using dtu.blognet.Application.Web.Models.PostViewModels;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class PostController : Controller
    {
        public PostController()
        {
            
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromServices] PostCommandHandlerFactory postCommandHandlerFactory, PostInputModel model)
        {
            var command = new AddPostAsyncCommand {Model = model};
            var handler = postCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(int blogId)
        {
            var viewModel = new PostViewModel {BlogId = blogId};
            return View(viewModel);
        }
        
        
    }
}
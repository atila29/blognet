using System.Threading.Tasks;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class CommentController : Controller
    {

    [HttpPost]
    public async Task<IActionResult> CreateComment([FromServices] CommentCommandHandlerFactory commentCommandHandlerFactory, CommentInputModel model)
    {

        return Ok();
    }
    }
}

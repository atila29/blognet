using System.Linq;
using System.Threading.Tasks;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Query.Queries;
using dtu.blognet.Core.Query.Queries.Blogs;
using dtu.blognet.Core.Query.QueryFactories;
using dtu.blognet.Core.Query.QueryFactories.Blog;
using dtu.blognet.Infrastructure.DataAccess.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class BlogController : Controller
    {
        public BlogController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromServices] BlogCommandHandlerFactory blogCommandHandlerFactory, BlogInputModel model)
        {
            var command = new AddBlogAsyncCommand {Model = model};
            var handler = blogCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog([FromServices] BlogCommandHandlerFactory blogCommandHandlerFactory, int id)
        {
            var command = new DeleteBlogAsyncCommand { Id = id };
            var handler = blogCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromServices] BlogQueryFactory blogFactory)
        {
            var query = new AllBlogsQueryAsync();
            var blogs = await blogFactory.Build(query).Get().ToList();
            return View();
        }
        
    }
}
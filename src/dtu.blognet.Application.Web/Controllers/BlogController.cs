using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Application.Web.Models.BlogViewModels;
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
        private readonly IMapper _mapper;

        public BlogController(IMapper mapper)
        {
            _mapper = mapper;
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
            var viewModel = _mapper.Map<BlogIndexViewModel>(blogs);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpGet]
        public IActionResult View([FromServices] BlogQueryFactory blogQueryFactory, BlogFromIdQuery query)
        {
            var blog = blogQueryFactory.Build(query).Get();
            var viewModel = _mapper.Map<BlogViewModel>(blog);
            return View(viewModel);
        }
        
        
    }
}
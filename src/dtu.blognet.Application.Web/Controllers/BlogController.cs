using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Application.Web.Models.BlogViewModels;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries;
using dtu.blognet.Core.Query.Queries.BlogQueries;
using dtu.blognet.Core.Query.QueryFactories;
using dtu.blognet.Infrastructure.DataAccess.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Account> _userManager;

        public BlogController(IMapper mapper, UserManager<Account> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] BlogCommandHandlerFactory blogCommandHandlerFactory, AddBlogAsyncCommand command)
        {
            command.OwnerId = _userManager.GetUserId(User);
            var handler = blogCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return RedirectToAction("Profile", "Account");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromServices] BlogCommandHandlerFactory blogCommandHandlerFactory, int id)
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

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult View([FromServices] BlogQueryFactory blogQueryFactory, BlogFromIdQuery query)
        {
            var blog = blogQueryFactory.Build(query).Get();
            var viewModel = _mapper.Map<BlogViewModel>(blog);
            viewModel.IsOwner = blog.OwnerId == _userManager.GetUserId(User);
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Subscribe()
        {
            return Ok();
        }
        
    }
}
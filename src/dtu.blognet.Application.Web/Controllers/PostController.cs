using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Application.Web.Models.PostViewModels;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.InputModels.PostInputModels;
using dtu.blognet.Core.Query.Queries.PostQueries;
using dtu.blognet.Core.Query.QueryFactories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dtu.blognet.Application.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IMapper _mapper;

        public PostController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] PostCommandHandlerFactory postCommandHandlerFactory, PostInputModel model)
        {
            var command = new AddPostAsyncCommand {Model = model};
            var handler = postCommandHandlerFactory.Build(command);
            var response = await handler.Execute();
            return RedirectToAction("View", response.Response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(int blogId)
        {
            var viewModel = new PostViewModel {BlogId = blogId};
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult View([FromServices] PostQueryFactory postQueryFactory, PostFromIdQuery query)
        {
            var post = postQueryFactory.Build(query).Get();
            var viewModel = _mapper.Map<PostViewModel>(post);
            return View(viewModel);
        }
    }
}
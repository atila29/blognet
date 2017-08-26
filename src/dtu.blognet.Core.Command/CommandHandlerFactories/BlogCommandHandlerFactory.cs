using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Infrastructure.DataAccess;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.CommandHandlerFactories
{
    public class BlogCommandHandlerFactory
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlogCommandHandlerFactory(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICommandHandler<AddBlogAsyncCommand, Task<CommandResponse>> Build(AddBlogAsyncCommand command)
        {
            return new AddBlogAsyncCommandHandler(_context, _mapper, command);
        }

        public ICommandHandler<DeleteBlogAsyncCommand, Task<CommandResponse>> Build(DeleteBlogAsyncCommand command)
        {
            return new DeleteBlogAsyncCommandHandler(_context, _mapper, command);
        }
    }
}
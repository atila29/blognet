using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers;
using dtu.blognet.Core.Command.CommandHandlers.PostCommandHandlers;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlerFactories
{
    public class PostCommandHandlerFactory
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostCommandHandlerFactory(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICommandHandler<AddPostAsyncCommand, Task<CommandResponse>> Build(AddPostAsyncCommand command)
        {
            return new AddPostAsyncCommandHandler(_context, _mapper, command);
        }
    }
}
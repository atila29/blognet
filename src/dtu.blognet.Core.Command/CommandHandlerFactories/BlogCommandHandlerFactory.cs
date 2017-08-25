using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Infrastructure.DataAccess;

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

        public ICommandHandler<AddBlogCommand, CommandResponse> Build(AddBlogCommand command)
        {
            return new AddBlogCommandHandler(_context, _mapper, command);
        }
    }
}
using dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlerFactories
{
    public class BlogCommandHandleFactory
    {
      private readonly ApplicationDbContext _context;

      public BlogCommandHandleFactory(ApplicationDbContext context)
      {
        _context = context;
      }

      public ICommandHandler<AddBlogCommand, CommandResponse> Build(AddBlogCommand command)
      {
        return new AddBlogCommandHandler(_context, command);
      }
      
    }
}

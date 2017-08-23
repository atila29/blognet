using dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Command.MappingInterfaces;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlerFactories
{
    public class BlogCommandHandlerFactory
    {
        private readonly IMappingInterface<BlogInputModel, Blog> _blogInputModel2Blog;
        private readonly ApplicationDbContext _context;

        public BlogCommandHandlerFactory(ApplicationDbContext context,
            IMappingInterface<BlogInputModel, Blog> blogInputModel2Blog)
        {
            _context = context;
            _blogInputModel2Blog = blogInputModel2Blog;
        }

        public ICommandHandler<AddBlogCommand, CommandResponse> Build(AddBlogCommand command)
        {
            return new AddBlogCommandHandler(_context, _blogInputModel2Blog, command);
        }
    }
}
using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlers.CommentCommandHandlers;
using dtu.blognet.Core.Command.Commands.CommentCommands;
using dtu.blognet.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.CommandHandlerFactories
{
    public class CommentCommandHandlerFactory
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentCommandHandlerFactory(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ICommandHandler<AddCommentAsyncCommand, Task<CommandResponse>> Build(AddCommentAsyncCommand command)
        {
            return new AddCommentAsyncCommandHandler(_context, _mapper, command);
        }
    }
}

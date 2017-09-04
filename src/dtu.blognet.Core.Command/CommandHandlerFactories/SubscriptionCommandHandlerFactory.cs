using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlers.PostCommandHandlers;
using dtu.blognet.Core.Command.CommandHandlers.SubscriptionCommandHandlers;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Command.Commands.SubscriptionCommands;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlerFactories
{
    public class SubscriptionCommandHandlerFactory
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionCommandHandlerFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICommandHandler<AddSubscriptionCommand, Task<CommandResponse>> Build(AddSubscriptionCommand command)
        {
            return new AddSubscriptionCommandHandler(_context, command);
        }
    }
}
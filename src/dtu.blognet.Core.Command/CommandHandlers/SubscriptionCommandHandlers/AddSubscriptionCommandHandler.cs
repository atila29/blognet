using System;
using System.Dynamic;
using System.Threading.Tasks;
using dtu.blognet.Core.Command.Commands.SubscriptionCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlers.SubscriptionCommandHandlers
{
    public class AddSubscriptionCommandHandler : BaseCommandHandler, ICommandHandler<AddSubscriptionCommand, Task<CommandResponse>>
    {
        private readonly AddSubscriptionCommand _command;
        public async Task<CommandResponse> Execute()
        {
            var subscription = new Subscription
            {
                AccountId = _command.AccountId,
                BlogId = _command.BlogId
            };
            var response = new CommandResponse
            {
                Success = false
            };
            
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.Subscriptions.AddAsync(subscription);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                    response.Success = true;
                }
                catch (Exception e)
                {
                    //TODO: ADD LOG!!!
                    Console.WriteLine(e);
                    transaction.Rollback();
                }
            }
            return response;
        }

        public AddSubscriptionCommandHandler(ApplicationDbContext dbContext, AddSubscriptionCommand command) : base(dbContext)
        {
            _command = command;
        }
    }
}
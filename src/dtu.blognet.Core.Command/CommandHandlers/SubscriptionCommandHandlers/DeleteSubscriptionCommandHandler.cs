using System;
using System.Threading.Tasks;
using dtu.blognet.Core.Command.Commands.SubscriptionCommands;
using dtu.blognet.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Core.Command.CommandHandlers.SubscriptionCommandHandlers
{
    public class DeleteSubscriptionCommandHandler : BaseCommandHandler, ICommandHandler<DeleteSubscriptionCommand, Task<CommandResponse>>
    {
        private readonly DeleteSubscriptionCommand _command;

        public DeleteSubscriptionCommandHandler(DeleteSubscriptionCommand command, ApplicationDbContext dbContext) : base(dbContext)
        {
            _command = command;
        }

        public async Task<CommandResponse> Execute()
        {
            var response = new CommandResponse
            {
                Success = false
            };
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var subscription = await _dbContext.Subscriptions.SingleAsync(sub => sub.AccountId == _command.AccountId && sub.BlogId == _command.BlogId);
                    _dbContext.Subscriptions.Remove(subscription);
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
    }
}
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.Commands.SubscriptionCommands
{
    public class DeleteSubscriptionCommand : ICommand<Task<CommandResponse>>
    {
        public string AccountId { get; set; }
        public int BlogId { get; set; }
    }
}
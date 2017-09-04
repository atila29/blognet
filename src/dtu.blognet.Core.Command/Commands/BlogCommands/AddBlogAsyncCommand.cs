using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.Commands.BlogCommands
{
    public class AddBlogAsyncCommand : ICommand<Task<CommandResponse>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public string Tags { get; set; }
    }
}
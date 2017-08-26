using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.Commands.BlogCommands
{
    public class AddBlogAsyncCommand : ICommand<Task<CommandResponse>>
    {
        public BlogInputModel Model { get; set; }
    }
}
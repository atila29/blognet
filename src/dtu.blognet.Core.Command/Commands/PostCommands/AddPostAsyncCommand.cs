using System.Threading.Tasks;
using dtu.blognet.Core.Command.InputModels.PostInputModels;

namespace dtu.blognet.Core.Command.Commands.PostCommands
{
    public class AddPostAsyncCommand : ICommand<Task<CommandResponse>>
    {
        public PostInputModel Model { get; set; }
    }
}
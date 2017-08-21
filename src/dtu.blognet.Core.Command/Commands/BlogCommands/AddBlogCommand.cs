using dtu.blognet.Core.Command.InputModels.BlogInputModels;

namespace dtu.blognet.Core.Command.Commands.BlogCommands
{
    public class AddBlogCommand : ICommand<CommandResponse>
    {
        public BlogInputModel Model { get; set; }
        
    }
}


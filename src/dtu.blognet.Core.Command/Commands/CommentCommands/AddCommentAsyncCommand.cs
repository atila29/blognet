using dtu.blognet.Core.Command.InputModels.CommentInputModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.Commands.CommentCommands
{
    public class AddCommentAsyncCommand : ICommand<Task<CommandResponse>>
    {
        public CommentInputModel Model { get; set; }
    }
}

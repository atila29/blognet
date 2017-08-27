using dtu.blognet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.Commands.BlogCommands
{
    public class DeleteBlogAsyncCommand : ICommand<Task<CommandResponse>>
    {
        public int Id { get; set; }
    }
}

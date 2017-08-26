using AutoMapper;
using dtu.blognet.Core.Command.Commands.CommentCommands;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.CommandHandlers.CommentCommandHandlers
{
    class AddCommentAsyncCommandHandler : BaseCommandHandler, ICommandHandler<AddCommentAsyncCommand, Task<CommandResponse>>
    {
        private readonly AddCommentAsyncCommand _command;
        private readonly IMapper _mapper;

        public AddCommentAsyncCommandHandler(ApplicationDbContext dbContext, IMapper mapper, AddCommentAsyncCommand command) : base(dbContext)
        {
            _mapper = mapper;
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
                    var comment = _mapper.Map<Comment>(_command.Model);
                    await _dbContext.Comments.AddAsync(comment);
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

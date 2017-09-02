using AutoMapper;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers
{
    public class DeleteBlogAsyncCommandHandler : BaseCommandHandler, ICommandHandler<DeleteBlogAsyncCommand, Task<CommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly DeleteBlogAsyncCommand _command;

        public DeleteBlogAsyncCommandHandler(ApplicationDbContext dbContext,
            IMapper mapper, DeleteBlogAsyncCommand command) : base(dbContext)
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
                    _dbContext.Remove(_dbContext.Blogs.Single(x => x.Id == _command.Id));
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

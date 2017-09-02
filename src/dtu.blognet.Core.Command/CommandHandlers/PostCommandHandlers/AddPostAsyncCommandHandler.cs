using System;
using System.Dynamic;
using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Core.Command.Commands.PostCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace dtu.blognet.Core.Command.CommandHandlers.PostCommandHandlers
{
    public class AddPostAsyncCommandHandler : BaseCommandHandler, ICommandHandler<AddPostAsyncCommand, Task<CommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AddPostAsyncCommand _command;

        public AddPostAsyncCommandHandler(ApplicationDbContext dbContext, IMapper mapper, AddPostAsyncCommand command) : base(dbContext)
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
                    var post = _mapper.Map<Post>(_command.Model);
                    await _dbContext.Posts.AddAsync(post);
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                    response.Success = true;
                    response.Response = new ExpandoObject();
                    response.Response.Id = post.Id;
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
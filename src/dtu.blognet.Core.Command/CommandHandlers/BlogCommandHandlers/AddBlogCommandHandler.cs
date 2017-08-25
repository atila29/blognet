using System;
using AutoMapper;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers
{
    public class AddBlogCommandHandler : BaseCommandHandler, ICommandHandler<AddBlogCommand, CommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly AddBlogCommand _command;

        public AddBlogCommandHandler(ApplicationDbContext dbContext,
            IMapper mapper, AddBlogCommand command) : base(dbContext)
        {
          _mapper = mapper;
          _command = command;
        }


        public CommandResponse Execute()
        {
            var response = new CommandResponse
            {
                Success = false
            };

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var blog = _mapper.Map<Blog>(_command.Model);
                    _dbContext.Blogs.Add(blog);
                    _dbContext.SaveChanges();
                    transaction.Commit();
                    response.Success = true;
                }
                catch (Exception e)
                {
                    // LOG!!!
                    Console.WriteLine(e);
                    transaction.Rollback();
                }
            }
            return response;
        }
    }
}
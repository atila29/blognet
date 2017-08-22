using System;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers
{
    public class AddBlogCommandHandler : BaseCommandHandler, ICommandHandler<AddBlogCommand, CommandResponse>
    {
        private readonly AddBlogCommand _command;
    
        public AddBlogCommandHandler(ApplicationDbContext dbContext, AddBlogCommand command) : base(dbContext)
        {
            _command = command;
        }
    
    
        public CommandResponse Execute()
        {
            var response = new CommandResponse()
            {
                Success = false
            };
          
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                // Should be automapper
                var blog = new Blog
                {
                    Title = _command.Model.Title
                };
                try
                {
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

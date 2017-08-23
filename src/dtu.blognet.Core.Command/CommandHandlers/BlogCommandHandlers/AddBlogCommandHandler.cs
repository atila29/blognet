using System;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Command.MappingInterfaces;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers
{
    public class AddBlogCommandHandler : BaseCommandHandler, ICommandHandler<AddBlogCommand, CommandResponse>
    {
        private readonly IMappingInterface<BlogInputModel, Blog> _blogInputModel2Blog;
        private readonly AddBlogCommand _command;

        public AddBlogCommandHandler(ApplicationDbContext dbContext,
            IMappingInterface<BlogInputModel, Blog> blogInputModel2Blog, AddBlogCommand command) : base(dbContext)
        {
            _blogInputModel2Blog = blogInputModel2Blog;
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
                    var blog = _blogInputModel2Blog.Convert(_command.Model);
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
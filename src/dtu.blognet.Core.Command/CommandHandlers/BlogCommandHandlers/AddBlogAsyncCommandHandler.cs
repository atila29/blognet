using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using System.Threading.Tasks;

namespace dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers
{
    public class AddBlogAsyncCommandHandler : BaseCommandHandler, ICommandHandler<AddBlogAsyncCommand, Task<CommandResponse>>
    {
        private readonly IMapper _mapper;
        private readonly AddBlogAsyncCommand _command;

        public AddBlogAsyncCommandHandler(ApplicationDbContext dbContext,
            IMapper mapper, AddBlogAsyncCommand command) : base(dbContext)
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
                    var blog = _mapper.Map<Blog>(_command);
                    blog.Tags = new List<BlogTag>();
                    
                    await _dbContext.Blogs.AddAsync(blog);
                    var tags = _command.Tags.Split(' ');
                    foreach (var tag in tags)
                    {
                        if (!_dbContext.Tags.Any(t => t.Name == tag))
                        {
                            var newTag = new Tag(tag);
                            _dbContext.Tags.Add(newTag);
                            blog.Tags.Add(new BlogTag{Tag = newTag, BlogId = blog.Id});
                        }
                        else
                        {
                            blog.Tags.Add(new BlogTag{TagId = _dbContext.Tags.Single(t => t.Name == tag).Id, BlogId = blog.Id});
                        }
                            
                        
                    }
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
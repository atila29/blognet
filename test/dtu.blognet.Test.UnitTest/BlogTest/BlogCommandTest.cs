using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlers.BlogCommandHandlers;
using dtu.blognet.Core.Command.Commands.BlogCommands;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace dtu.blognet.Test.UnitTest.BlogTest
{
    public class BlogCommandTest : BaseTest
    {
        
        
        
        [Fact]
        public async Task AddBlogAsync()
        {
            // Arrange.  
            string expectedDescription = "desc001";
            string expectedTitle = "test";
            
            var command = new AddBlogAsyncCommand
            {
                Description = expectedDescription,
                OwnerId = DefaultAccount.Id,
                Tags = "",
                Title = expectedTitle
            };

            var handler = new AddBlogAsyncCommandHandler(DbContext, Provider.GetService<IMapper>(), command);

            // Act.
            await handler.Execute();
            // Assert.
            Assert.True(DbContext.Blogs.Any(blog => blog.Title == expectedTitle));
        }
    }
}
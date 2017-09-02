using System.Collections.Generic;

namespace dtu.blognet.Core.Query.Queries.Blog
{
    public class AllBlogsQueryAsync : IQuery<IAsyncEnumerable<Entities.Blog>>, IQuery<IAsyncEnumerable<Entities.Comment>>
    {
        
    }
}
using System.Collections.Generic;
using dtu.blognet.Core.Query.Queries;
using dtu.blognet.Core.Query.Queries.Blogs;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace dtu.blognet.Core.Query.QueryHandlers.Blog
{
    public class AllBlogsQueryAsyncHandler : IQueryHandler<AllBlogsQueryAsync, IAsyncEnumerable<Entities.Blog>>
    {
        private readonly QueryDb _queryDb;

        public AllBlogsQueryAsyncHandler(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }
        
        public IAsyncEnumerable<Entities.Blog> Get()
        {
            return _queryDb.Blogs.AsAsyncEnumerable();
        }
    }
}
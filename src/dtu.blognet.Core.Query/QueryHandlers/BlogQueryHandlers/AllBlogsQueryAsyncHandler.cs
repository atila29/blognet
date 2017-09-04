using System.Collections.Generic;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.BlogQueries;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace dtu.blognet.Core.Query.QueryHandlers.BlogQueryHandlers
{
    public class AllBlogsQueryAsyncHandler : IQueryHandler<AllBlogsQueryAsync, IAsyncEnumerable<Blog>>
    {
        private readonly QueryDb _queryDb;

        public AllBlogsQueryAsyncHandler(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }
        
        public IAsyncEnumerable<Blog> Get()
        {
            return _queryDb.Blogs.AsAsyncEnumerable();
        }
    }
}
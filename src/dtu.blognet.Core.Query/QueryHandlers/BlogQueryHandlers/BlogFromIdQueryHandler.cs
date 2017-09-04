using System.Linq;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.BlogQueries;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Core.Query.QueryHandlers.BlogQueryHandlers
{
    public class BlogFromIdQueryHandler : IQueryHandler<BlogFromIdQuery, Blog>
    {
        private readonly QueryDb _queryDb;
        private readonly BlogFromIdQuery _query;

        public BlogFromIdQueryHandler(QueryDb queryDb, BlogFromIdQuery query)
        {
            _queryDb = queryDb;
            _query = query;
        }
        
        
        public Blog Get()
        {
            return _queryDb.Blogs.Include(blog => blog.Posts).Single(blog => blog.Id == _query.Id);
        }
    }
}
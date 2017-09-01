﻿using System.Linq;
using dtu.blognet.Core.Query.Queries.Blog;

namespace dtu.blognet.Core.Query.QueryHandlers.Blog
{
    public class BlogFromIdQueryHandler : IQueryHandler<BlogFromIdQuery, Entities.Blog>
    {
        private readonly QueryDb _queryDb;
        private readonly BlogFromIdQuery _query;

        public BlogFromIdQueryHandler(QueryDb queryDb, BlogFromIdQuery query)
        {
            _queryDb = queryDb;
            _query = query;
        }
        
        
        public Entities.Blog Get()
        {
            return _queryDb.Blogs.Single(blog => blog.Id == _query.Id);
        }
    }
}
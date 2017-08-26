﻿using System.Collections.Generic;
using dtu.blognet.Core.Query.Queries;
using dtu.blognet.Core.Query.Queries.Blogs;
using dtu.blognet.Core.Query.QueryHandlers.Blog;

namespace dtu.blognet.Core.Query.QueryFactories.Blog
{
    /// <summary>
    ///     Factory for building Blog queries.
    ///     Should be DI.
    /// </summary>
    public class BlogQueryFactory
    {
        private readonly QueryDb _queryDb;

        public BlogQueryFactory(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }


        /// <summary>
        ///     Query returns all blogs in arbitrary order.
        /// </summary>
        /// <param name="query">All blogs query</param>
        /// <returns>The queryHandler</returns>
        public IQueryHandler<AllblogsQuery, IEnumerable<Entities.Blog>> Build(AllblogsQuery query)
        {
            return new AllBlogsQueryHandler(_queryDb);
        }

        public IQueryHandler<AllBlogsQueryAsync, IAsyncEnumerable<Entities.Blog>> Build(AllBlogsQueryAsync queryAsync)
        {
            return new AllBlogsQueryAsyncHandler(_queryDb);
        }
    }
}
using System.Collections.Generic;
using dtu.blognet.Core.Query.Queries.Blog;

namespace dtu.blognet.Core.Query.QueryHandlers.Blog
{
    /// <summary>
    ///     QueryHandler for all blogs.
    /// </summary>
    public class AllBlogsQueryHandler : IQueryHandler<AllblogsQuery, IEnumerable<Entities.Blog>>
    {
        private readonly QueryDb _queryDb;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="queryDb">Instance of QueryDb</param>
        public AllBlogsQueryHandler(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }

        /// <summary>
        ///     The inherited method.
        /// </summary>
        /// <returns>All blogs</returns>
        public IEnumerable<Entities.Blog> Get()
        {
            return _queryDb.Blogs;
        }
    }
}
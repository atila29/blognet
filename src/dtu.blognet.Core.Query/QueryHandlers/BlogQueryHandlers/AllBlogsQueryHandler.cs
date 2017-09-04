using System.Collections.Generic;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.BlogQueries;

namespace dtu.blognet.Core.Query.QueryHandlers.BlogQueryHandlers
{
    /// <summary>
    ///     QueryHandler for all blogs.
    /// </summary>
    public class AllBlogsQueryHandler : IQueryHandler<AllblogsQuery, IEnumerable<Blog>>
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
        public IEnumerable<Blog> Get()
        {
            return _queryDb.Blogs;
        }
    }
}
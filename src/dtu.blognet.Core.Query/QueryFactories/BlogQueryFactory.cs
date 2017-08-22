using System.Collections.Generic;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries;
using dtu.blognet.Core.Query.QueryHandlers;

namespace dtu.blognet.Core.Query.QueryFactories
{
    /// <summary>
    /// Factory for building Blog queries.
    /// Should be DI.
    /// </summary>
    public class BlogQueryFactory
    {
        private readonly QueryDb _queryDb;
        public BlogQueryFactory(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }
      
      
        /// <summary>
        /// Query returns all blogs in arbitrary order.
        /// </summary>
        /// <param name="query">All blogs query</param>
        /// <returns>The queryHandler</returns>
        public IQueryHandler<AllblogsQuery, IEnumerable<Blog>> Build(AllblogsQuery query)
        {
            return new AllBlogsQueryHandler(_queryDb);
        }
    }
}

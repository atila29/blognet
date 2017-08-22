using System.Collections.Generic;
using System.Threading.Tasks;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace dtu.blognet.Core.Query.QueryHandlers
{
    /// <summary>
    /// QueryHandler for all blogs.
    /// </summary>
    public class AllBlogsQueryHandler : IQueryHandler<AllblogsQuery, IEnumerable<Blog>>
    {
        private readonly QueryDb _queryDb;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="queryDb">Instance of QueryDb</param>
        public AllBlogsQueryHandler(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }
        
        /// <summary>
        /// The inherited method.
        /// </summary>
        /// <returns>All blogs</returns>
        public IEnumerable<Blog> Get()
        {
            return _queryDb.Blogs;
        }

        public async Task<IEnumerable<Blog>> GetAsync()
        {
            return await _queryDb.Blogs.ToListAsync();
        }
    }
}

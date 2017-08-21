using System.Collections.Generic;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries;

namespace dtu.blognet.Core.Query.QueryHandlers
{
    public class AllBlogsQueryHandler : IQueryHandler<AllblogsQuery, IEnumerable<Blog>>
    {
      private readonly QueryDb _queryDb;

      public AllBlogsQueryHandler(QueryDb queryDb)
      {
          _queryDb = queryDb;
      }

      public IEnumerable<Blog> Get()
      {
          return _queryDb.Blogs;
      }
    }
}

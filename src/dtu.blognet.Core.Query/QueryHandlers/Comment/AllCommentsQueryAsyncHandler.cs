using System.Collections.Generic;
using System.Linq;
using dtu.blognet.Core.Query.Queries.Comment;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace dtu.blognet.Core.Query.QueryHandlers.Comment
{
    public class AllCommentsQueryAsyncHandler : IQueryHandler<AllCommentsQueryAsync, IAsyncEnumerable<Entities.Comment>>
    {
        private readonly QueryDb _queryDb;
        private readonly AllCommentsQueryAsync _query;

        public AllCommentsQueryAsyncHandler(QueryDb queryDb, AllCommentsQueryAsync query)
        {
            _queryDb = queryDb;
            _query = query;
        }

        public IAsyncEnumerable<Entities.Comment> Get()
        {
            return _queryDb.Comments.Where(comment => comment.PostId == _query.PostId).AsAsyncEnumerable();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.CommentQueries;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace dtu.blognet.Core.Query.QueryHandlers.CommentQueryHandlers
{
    public class AllCommentsQueryAsyncHandler : IQueryHandler<AllCommentsQueryAsync, IAsyncEnumerable<Comment>>
    {
        private readonly QueryDb _queryDb;
        private readonly AllCommentsQueryAsync _query;

        public AllCommentsQueryAsyncHandler(QueryDb queryDb, AllCommentsQueryAsync query)
        {
            _queryDb = queryDb;
            _query = query;
        }

        public IAsyncEnumerable<Comment> Get()
        {
            return _queryDb.Comments.Where(comment => comment.PostId == _query.PostId).AsAsyncEnumerable();
        }
    }
}
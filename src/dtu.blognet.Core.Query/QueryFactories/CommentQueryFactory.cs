using System.Collections.Generic;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.CommentQueries;
using dtu.blognet.Core.Query.QueryHandlers.CommentQueryHandlers;

namespace dtu.blognet.Core.Query.QueryFactories
{
    public class CommentQueryFactory
    {
        private readonly QueryDb _queryDb;

        public CommentQueryFactory(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }

        public IQueryHandler<AllCommentsQueryAsync, IAsyncEnumerable<Comment>> Build(AllCommentsQueryAsync query)
        {
            return new AllCommentsQueryAsyncHandler(_queryDb, query);
        }
    }
}
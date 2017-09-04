using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.PostQueries;
using dtu.blognet.Core.Query.QueryHandlers.Post;

namespace dtu.blognet.Core.Query.QueryFactories
{
    public class PostQueryFactory
    {
        private readonly QueryDb _queryDb;

        public PostQueryFactory(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }

        public IQueryHandler<PostFromIdQuery, Post> Build(PostFromIdQuery query)
        {
            return new PostFromIdQueryHandler(_queryDb, query);
        }
        
        
    }
}
using System.Linq;
using dtu.blognet.Core.Query.Queries.Post;

namespace dtu.blognet.Core.Query.QueryHandlers.Post
{
    public class PostFromIdQueryHandler : IQueryHandler<PostFromIdQuery, Entities.Post>
    {
        private readonly QueryDb _queryDb;
        private readonly PostFromIdQuery _query;

        public PostFromIdQueryHandler(QueryDb queryDb, PostFromIdQuery query)
        {
            _queryDb = queryDb;
            _query = query;
        }
        
        
        public Entities.Post Get()
        {
            return _queryDb.Posts.Single(post => post.Id == _query.Id);
        }
    }
}
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Core.Query.Queries.PostQueries
{
    public class PostFromIdQuery : IQuery<Post>
    {
        public int Id { get; set; }
    }
}
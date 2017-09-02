using dtu.blognet.Core.Entities;
namespace dtu.blognet.Core.Query.Queries.Post
{
    public class PostFromIdQuery : IQuery<Entities.Post>
    {
        public int Id { get; set; }
    }
}
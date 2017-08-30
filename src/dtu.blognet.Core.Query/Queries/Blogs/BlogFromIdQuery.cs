using dtu.blognet.Core.Entities;

namespace dtu.blognet.Core.Query.Queries.Blogs
{
    public class BlogFromIdQuery : IQuery<Blog>
    {
        public int Id { get; set; }
    }
}
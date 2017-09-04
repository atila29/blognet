using dtu.blognet.Core.Entities;

namespace dtu.blognet.Core.Query.Queries.BlogQueries
{
    public class BlogFromIdQuery : IQuery<Blog>
    {
        public int Id { get; set; }
    }
}
namespace dtu.blognet.Core.Query.Queries.Blog
{
    public class BlogFromIdQuery : IQuery<Entities.Blog>
    {
        public int Id { get; set; }
    }
}
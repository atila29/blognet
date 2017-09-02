using System.Collections.Generic;

namespace dtu.blognet.Core.Query.Queries.Comment
{
    public class AllCommentsQueryAsync : IQuery<IAsyncEnumerable<Entities.Comment>>
    {
        public int PostId { get; set; }
    }
}
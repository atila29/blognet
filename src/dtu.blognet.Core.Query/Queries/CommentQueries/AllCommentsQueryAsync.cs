using System.Collections.Generic;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Core.Query.Queries.CommentQueries
{
    public class AllCommentsQueryAsync : IQuery<IAsyncEnumerable<Comment>>
    {
        public int PostId { get; set; }
    }
}
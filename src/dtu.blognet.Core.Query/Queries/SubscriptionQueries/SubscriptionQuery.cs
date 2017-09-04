using dtu.blognet.Core.Entities;

namespace dtu.blognet.Core.Query.Queries.SubscriptionQueries
{
    public class SubscriptionQuery : IQuery<bool>
    {
        public string AccountId { get; set; }
        public int BlogId { get; set; }
    }
}
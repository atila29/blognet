using System.Linq;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.SubscriptionQueries;

namespace dtu.blognet.Core.Query.QueryHandlers.SubscriptionQueryHandlers
{
    public class SubscriptionQueryHandler : IQueryHandler<SubscriptionQuery, bool>
    {
        private readonly SubscriptionQuery _query;
        private readonly QueryDb _queryDb;

        public SubscriptionQueryHandler(SubscriptionQuery query, QueryDb queryDb)
        {
            _query = query;
            _queryDb = queryDb;
        }

        public bool Get()
        {
            return _queryDb.Subscriptions.Any(subscription =>
                subscription.AccountId == _query.AccountId && subscription.BlogId == _query.BlogId);
        }
    }
}
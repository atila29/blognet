using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.SubscriptionQueries;
using dtu.blognet.Core.Query.QueryHandlers.SubscriptionQueryHandlers;

namespace dtu.blognet.Core.Query.QueryFactories
{
    public class SubscriptionQueryFactory
    {
        private readonly QueryDb _queryDb;

        public SubscriptionQueryFactory(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }


        public IQueryHandler<SubscriptionQuery, bool> Build(SubscriptionQuery query)
        {
            return new SubscriptionQueryHandler(query, _queryDb);
        }
    }
}
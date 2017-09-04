using dtu.blognet.Core.Query.Queries.AccountQueries;
using dtu.blognet.Core.Query.QueryHandlers.AccountQueryHandlers;

namespace dtu.blognet.Core.Query.QueryFactories
{
    public class AccountQueryFactory
    {
        private readonly QueryDb _queryDb;

        public AccountQueryFactory(QueryDb queryDb)
        {
            _queryDb = queryDb;
        }

        public IQueryHandler<AccountFromIdQuery, Entities.Account> Build(AccountFromIdQuery query)
        {
            return new AccountFromIdQueryHandler(_queryDb, query);
        }
        
        
    }
}
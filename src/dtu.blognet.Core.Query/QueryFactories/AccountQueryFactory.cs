using dtu.blognet.Core.Query.Queries.Account;
using dtu.blognet.Core.Query.QueryHandlers.Account;

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
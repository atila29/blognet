using System.Linq;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query.Queries.AccountQueries;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Core.Query.QueryHandlers.AccountQueryHandlers
{
    public class AccountFromIdQueryHandler : IQueryHandler<AccountFromIdQuery, Account>
    {
        private readonly QueryDb _queryDb;
        private readonly AccountFromIdQuery _query;

        public AccountFromIdQueryHandler(QueryDb queryDb, AccountFromIdQuery query)
        {
            _queryDb = queryDb;
            _query = query;
        }
        
        public Account Get()
        {
            return _queryDb.Users.Include(account => account.OwnedBlogs).Single(account => account.Id == _query.Id);
        }
    }
}
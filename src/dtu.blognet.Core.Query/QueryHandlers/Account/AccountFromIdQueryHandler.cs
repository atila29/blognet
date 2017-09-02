﻿using System.Linq;
using dtu.blognet.Core.Query.Queries.Account;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Core.Query.QueryHandlers.Account
{
    public class AccountFromIdQueryHandler : IQueryHandler<AccountFromIdQuery, Entities.Account>
    {
        private readonly QueryDb _queryDb;
        private readonly AccountFromIdQuery _query;

        public AccountFromIdQueryHandler(QueryDb queryDb, AccountFromIdQuery query)
        {
            _queryDb = queryDb;
            _query = query;
        }
        
        public Entities.Account Get()
        {
            return _queryDb.Users.Include(account => account.OwnedBlogs).Single(account => account.Id == _query.Id);
        }
    }
}
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Core.Query.Queries.AccountQueries
{
    public class AccountFromIdQuery : IQuery<Account>
    {
        public string Id { get; set; }
    }
}
namespace dtu.blognet.Core.Query.Queries.Account
{
    public class AccountFromIdQuery : IQuery<Entities.Account>
    {
        public string Id { get; set; }
    }
}
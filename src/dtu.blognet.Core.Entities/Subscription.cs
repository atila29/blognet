namespace dtu.blognet.Core.Entities
{
    public class Subscription
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public int BlogId { get; set; }
        
        public Account Account { get; set; }
        public Blog Blog { get; set; }
    }
}
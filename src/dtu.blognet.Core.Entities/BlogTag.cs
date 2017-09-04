namespace dtu.blognet.Core.Entities
{
    public class BlogTag
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public override string ToString()
        {
            return Tag.Name;
        }
    }
}
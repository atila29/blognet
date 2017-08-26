namespace dtu.blognet.Core.Entities
{
    public class Comment
    {
        //TODO: add owner
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
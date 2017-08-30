using System;

namespace dtu.blognet.Core.Entities
{
    public class Comment
    {
        public string CreaterId { get; set; }
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Account Creater { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
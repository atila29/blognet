using System.Collections;
using System.Collections.Generic;

namespace dtu.blognet.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<BlogTag> Tags { get; set; }
        public string OwnerId { get; set; }
        public virtual Account Owner { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
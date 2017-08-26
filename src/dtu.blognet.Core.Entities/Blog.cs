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
        // TODO: add owner account.
        // TODO: add subscribers 
    }
}
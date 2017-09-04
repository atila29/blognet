using System.Collections.Generic;

namespace dtu.blognet.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Blog> Blogs { get; set; }

        public Tag(string name)
        {
            Name = name;
        }

        public Tag()
        {
            
        }
    }
}
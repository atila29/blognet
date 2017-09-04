using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace dtu.blognet.Core.Entities
{
    public class Account : IdentityUser
    {
        public virtual ICollection<Blog> OwnedBlogs { get; set; }
        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}

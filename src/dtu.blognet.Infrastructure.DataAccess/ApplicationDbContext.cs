using dtu.blognet.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Infrastructure.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<BlogTag> BlogTags { get; set; }
    }
}
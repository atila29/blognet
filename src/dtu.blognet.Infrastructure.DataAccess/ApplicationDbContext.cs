using Microsoft.EntityFrameworkCore;
using dtu.blognet.Core.Entities;

namespace dtu.blognet.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Blog> Blogs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
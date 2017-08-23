using dtu.blognet.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Infrastructure.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
    }
}
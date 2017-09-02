using System;
using dtu.blognet.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Infrastructure.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<Account, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Blog>()
                .HasOne(blog => blog.Owner)
                .WithMany(account => account.OwnedBlogs)
                .HasForeignKey(blog => blog.OwnerId);
            base.OnModelCreating(builder);
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<BlogTag> BlogTags { get; set; }
    }
}
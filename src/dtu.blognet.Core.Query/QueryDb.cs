using System.Linq;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Core.Query
{
    public class QueryDb
    {
        private readonly ApplicationDbContext _dbContext;
  
        public QueryDb(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IQueryable<Blog> Blogs => _dbContext.Blogs.AsQueryable();

    }
}

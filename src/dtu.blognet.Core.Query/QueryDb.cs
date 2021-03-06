﻿using System.Linq;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace dtu.blognet.Core.Query
{
    /// <summary>
    ///     Class used as a layer for quering DB without tracking.
    /// </summary>
    public class QueryDb
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        ///     Constructor for QueryDb
        /// </summary>
        /// <param name="dbContext"></param>
        public QueryDb(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IQueryable<Blog> Blogs => _dbContext.Blogs.AsQueryable();
        public IQueryable<Account> Users => _dbContext.Users.AsQueryable();
        public IQueryable<Post> Posts => _dbContext.Posts.AsQueryable();
        public IQueryable<Comment> Comments => _dbContext.Comments.AsQueryable();
        public IQueryable<Subscription> Subscriptions => _dbContext.Subscriptions.AsQueryable();
    }
}
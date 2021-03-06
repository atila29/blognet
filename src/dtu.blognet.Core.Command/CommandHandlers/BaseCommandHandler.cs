﻿using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Core.Command.CommandHandlers
{
    public class BaseCommandHandler
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
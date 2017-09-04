using System;
using System.Threading.Tasks;
using AutoMapper;
using dtu.blognet.Core.Entities;
using dtu.blognet.Infrastructure.DataAccess;
using dtu.blognet.Services.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace dtu.blognet.Test.UnitTest
{
    public abstract class BaseTest
    {
        protected ApplicationDbContext DbContext;
        protected readonly IServiceProvider Provider;
        protected readonly Account DefaultAccount;
        private const string Seed = "lolz";
        
        protected BaseTest()
        {
            
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(opt => opt.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            
            
            DbContext = new ApplicationDbContext(options);
            
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<ApplicationDbContext>(provider => DbContext);
            
            // Add automapper.
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(MappingConfiguraition.GetMappingTypes());
            });
            services.AddSingleton<IMapper>(mapperConfig.CreateMapper());
            
            Provider = services.BuildServiceProvider();
            
            DefaultAccount = new Account { UserName = "default@d.d", Email = "default@d.d"};
            DbContext.Users.Add(DefaultAccount);
            DbContext.SaveChanges();
        }
    }
}
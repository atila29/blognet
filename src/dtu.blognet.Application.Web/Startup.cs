﻿using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Query;
using dtu.blognet.Core.Query.QueryFactories;
using dtu.blognet.Core.Query.QueryFactories.Blog;
using dtu.blognet.Infrastructure.DataAccess;
using dtu.blognet.Services.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dtu.blognet.Application.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("dtu.blognet.Infrastructure.DataAccess")));
            
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            // Add automapper.
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(MappingConfiguraition.GetMappingTypes());
            });
            services.AddSingleton<IMapper>(mapperConfig.CreateMapper());

            // Queries
            services.AddTransient<QueryDb, QueryDb>();
            services.AddTransient<BlogQueryFactory, BlogQueryFactory>();

            // Factories
            services.AddTransient<BlogCommandHandlerFactory, BlogCommandHandlerFactory>();
            services.AddTransient<PostCommandHandlerFactory, PostCommandHandlerFactory>();
            services.AddTransient<CommentCommandHandlerFactory, CommentCommandHandlerFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            ApplicationDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
            context.Database.Migrate();
        }
    }
}
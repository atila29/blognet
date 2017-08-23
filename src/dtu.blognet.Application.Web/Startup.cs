using System.Reflection;
using AutoMapper;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Command.InputModels.BlogInputModels;
using dtu.blognet.Core.Command.MappingInterfaces;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query;
using dtu.blognet.Core.Query.QueryFactories;
using dtu.blognet.Infrastructure.DataAccess;
using dtu.blognet.Services.Mapping;
using dtu.blognet.Services.Mapping.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            
            // Add automapper.
            services.AddSingleton<IMapper>(MappingConfiguraition.GetMappingConfig().CreateMapper());
            
            // Add mappings.
            services.AddTransient<IMappingInterface<BlogInputModel, Blog>, BlogInputModel2Blog>();

            services.AddTransient<QueryDb, QueryDb>();
            services.AddTransient<BlogQueryFactory, BlogQueryFactory>();

            services.AddTransient<BlogCommandHandlerFactory, BlogCommandHandlerFactory>();
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
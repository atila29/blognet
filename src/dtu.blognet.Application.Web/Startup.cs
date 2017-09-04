using System;
using AutoMapper;
using dtu.blognet.Application.Web.ConfigurationObjects;
using dtu.blognet.Application.Web.Services;
using dtu.blognet.Application.Web.Services.AutomapperProfiles;
using dtu.blognet.Core.Command.CommandHandlerFactories;
using dtu.blognet.Core.Entities;
using dtu.blognet.Core.Query;
using dtu.blognet.Core.Query.QueryFactories;
using dtu.blognet.Infrastructure.DataAccess;
using dtu.blognet.Services.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            
            services.AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            // Add JWT configuration object.
            services.Configure<JwtConfiguration>(Configuration.GetSection("JWTSettings"));
            
            // Add automapper.
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(MappingConfiguraition.GetMappingTypes());
                cfg.AddProfile(new ViewModelProfile());
            });
            services.AddSingleton<IMapper>(mapperConfig.CreateMapper());

            // Queries.
            services.AddTransient<QueryDb, QueryDb>();
            services.AddTransient<BlogQueryFactory, BlogQueryFactory>();
            services.AddTransient<AccountQueryFactory, AccountQueryFactory>();
            services.AddTransient<PostQueryFactory, PostQueryFactory>();
            services.AddTransient<CommentQueryFactory, CommentQueryFactory>();

            // Commands.
            services.AddTransient<BlogCommandHandlerFactory, BlogCommandHandlerFactory>();
            services.AddTransient<PostCommandHandlerFactory, PostCommandHandlerFactory>();
            services.AddTransient<CommentCommandHandlerFactory, CommentCommandHandlerFactory>();
            services.AddTransient<SubscriptionCommandHandlerFactory, SubscriptionCommandHandlerFactory>();

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

            var tokenParameters = new TokenValidationConfiguration(app.ApplicationServices.GetService<IOptions<JwtConfiguration>>()).GetTokenValidationParameters();
            
            
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                TokenValidationParameters = tokenParameters
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                LoginPath = new PathString("/Account/Login"),
                AutomaticAuthenticate = false,
                AutomaticChallenge = false
            });
            
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
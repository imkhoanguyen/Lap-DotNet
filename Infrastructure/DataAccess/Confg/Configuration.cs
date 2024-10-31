using Application.Abstract;
using Domain.Entities;
using Infrastructure.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DataAccess.Confg
{
    public static class Configuration
    {
        public static void RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");


            services.AddDbContext<BookContext>(opt =>opt.UseSqlite(connectionString));

            services.AddIdentity<AppUser, IdentityRole>()
                            .AddEntityFrameworkStores<BookContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void IdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //cookie config
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "CozaCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
            });

            // identity config
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(10000);
                opt.SignIn.RequireConfirmedEmail = false;
            });
        }
    }
}

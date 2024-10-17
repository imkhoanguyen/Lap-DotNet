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
    }
}

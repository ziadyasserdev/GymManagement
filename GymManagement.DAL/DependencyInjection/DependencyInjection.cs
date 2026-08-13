using GymManagement.DAL.Data.Contexts;
using GymManagement.DAL.Repositories.Implementations;
using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDAL(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GymDbConnection"));
            });
            services.AddScoped<IPlanRepository, PlanRepository>();
            return services;
        }
    }
}

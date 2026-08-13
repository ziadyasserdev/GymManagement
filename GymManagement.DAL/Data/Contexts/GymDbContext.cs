using GymManagement.DAL.Data.Configurations;
using GymManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Data.Contexts
{
    public class GymDbContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigurations());     
            base.OnModelCreating(modelBuilder);
        }
      
    }
}

using CQRS_Pattern.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CQRS_Pattern.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<CustomerDetails> customers { get; set; }
    }
}

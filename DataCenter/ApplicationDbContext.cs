using DataCenter.MealManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataCenter
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

            var connectionStringFromConfig = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionStringFromConfig);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace DataCenter
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext
            (DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
    }
}

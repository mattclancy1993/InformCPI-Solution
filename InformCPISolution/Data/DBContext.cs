using InformCPISolution.Models;
using Microsoft.EntityFrameworkCore;

namespace InformCPISolution.Data
{

    public class InformCPIDbContext : DbContext
    {
        public InformCPIDbContext(DbContextOptions<InformCPIDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }
    }

}

using DataPlus.Bar.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataPlus.Bar.Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Cube> Cubes { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public RepositoryContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}

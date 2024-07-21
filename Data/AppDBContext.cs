using DoorsSecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Data
{
    public class AppDBContext : DbContext 
    {
        public DbSet<Door> Doors { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("doorsSecurityInMemory");
        }
    }
}
using DoorsSecurity.Models;
using Microsoft.EntityFrameworkCore;

namespace DoorsSecurity.Data
{
    public class AppDBContext : DbContext 
    {
        public DbSet<Door> Doors { get; set; }
        public DbSet<Card> Cards { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Door>()
                .HasMany(d => d.Cards)
                .WithMany(c => c.Doors)
                .UsingEntity<Dictionary<string, object>>(
                    "DoorCard",
                    r => r.HasOne<Card>().WithMany().HasForeignKey("CardId"),
                    r => r.HasOne<Door>().WithMany().HasForeignKey("DoorId")
                );
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseInMemoryDatabase("doorsSecurityInMemory");
        }*/
    }
}
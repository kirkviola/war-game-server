using Microsoft.EntityFrameworkCore;

namespace war_game_server.Models
{
    public class WarDbContext : DbContext
    {
        // Virtual collections
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        // Constructor
        public WarDbContext(DbContextOptions<WarDbContext> options)
                : base(options) { }
        // Fluent Api
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Card>(c =>
            {
                c.ToTable("Cards");

                c.HasKey(c => c.Id);
                c.Property(x => x.Name).HasMaxLength(128).IsRequired();
                c.Property(x => x.Value).IsRequired();
                c.HasOne(x => x.Player)
                    .WithMany(x => x.Cards)
                    .HasForeignKey(x => x.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Player>(p =>
            {
                p.ToTable("Players");

                p.HasKey(x => x.Id);
                p.Property(x => x.Name).HasMaxLength(128).IsRequired();

            });
        }
    }
}

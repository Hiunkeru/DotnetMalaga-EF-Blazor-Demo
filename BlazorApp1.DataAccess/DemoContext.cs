using BlazorApp1.DataAccess.Contracts;
using BlazorApp1.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp1.DataAccess
{
    public class DemoContext : DbContext, IDemoContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Warrior> Warrior { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .ToTable("Game");

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Game)
                .WithMany(g => g.Players)
                .HasForeignKey(p => p.GameId);
            modelBuilder.Entity<Player>().ToTable("Player");

            modelBuilder.Entity<Warrior>()
                .HasMany(w => w.Players)
                .WithOne(p => p.Warrior);
            modelBuilder.Entity<Warrior>()
                .ToTable("Warrior");
        }
    }
}

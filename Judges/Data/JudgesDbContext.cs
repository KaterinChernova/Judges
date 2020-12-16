using Judges.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Judges.Data
{
    public class JudgesDbContext : DbContext
    {
        public JudgesDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Judge> Judges { get; set; }

        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Judge>()
                .HasOne<Sport>(j => j.Sport)
                .WithMany(s => s.Judges);
        }
    }
}

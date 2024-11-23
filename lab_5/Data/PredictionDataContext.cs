using Lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Data
{
    public class PredictionDataContext : DbContext
    {
        public PredictionDataContext(DbContextOptions<PredictionDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Prediction> Prediction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Prediction>().HasKey(e => e.PredectionId);
        }
    }
}
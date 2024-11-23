using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Data
{
    public class NewsDbContext : DbContext
    {



        public DbSet<Lab4.Models.Client> Clients { get; set; }
        public DbSet<Lab4.Models.NewsBoard> NewsBoards { get; set; }


        public DbSet<Lab4.Models.Subscription> Subscriptions { get; set; }

        public DbSet<News> News { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) 
        { 

         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lab4.Models.Client>().ToTable("Client");
            modelBuilder.Entity<Lab4.Models.NewsBoard>().ToTable("NewsBoard");

            modelBuilder.Entity<Subscription>().
                HasKey(c => new { c.ClientId, c.NewsBoardId });



            
            modelBuilder.Entity<Client>().HasKey(x => x.Id);
            modelBuilder.Entity<NewsBoard>().HasKey(x => x.Id);

            
            modelBuilder.Entity<News>().HasKey(x => x.Id);

            modelBuilder.Entity<News>()
                .HasOne<NewsBoard>(c => c.NewsBoard)
                .WithMany(s=>s.News).HasForeignKey(c=>c.NewsBoardID);

        

        }



    }
}

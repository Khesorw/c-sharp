using Microsoft.EntityFrameworkCore;

namespace Lab4.Data
{
    public class NewsDbContext : DbContext
    {

        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) { }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options) { 
        
            Database.EnsureCreated();
        
        }
        
    }
}
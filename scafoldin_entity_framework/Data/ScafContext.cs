using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scaf.Models;

namespace Scaf.Data
{
    public class ScafContext : DbContext
    {
        public ScafContext (DbContextOptions<ScafContext> options)
            : base(options)
        {
        }

        public DbSet<Scaf.Models.Student> Student { get; set; } = default!;
    }
}

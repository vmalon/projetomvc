using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models
{
    public class WebApplication7Context : DbContext
    {
        public WebApplication7Context (DbContextOptions<WebApplication7Context> options)
            : base(options)
        {
        }

        public DbSet<Departments> Departments { get; set; }
        public DbSet<Departments> Seller { get; set; }
        public DbSet<Departments> SalesRecord { get; set; }

    }
}

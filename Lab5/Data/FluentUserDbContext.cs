using Lab5;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab5.Data
{
    public class FluentUserDbContext : DbContext
    {
        public FluentUserDbContext(DbContextOptions<FluentUserDbContext> options)
            : base(options)
        {
        }

        public DbSet<FluentUser> FluentUsers { get; set; }
    }
}
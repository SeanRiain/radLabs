using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab4Part4.Models;
namespace Lab4Part4.Data
{
    public class Lab4Context : DbContext
    {
        public Lab4Context(DbContextOptions<Lab4Context> options)
            : base(options)
        {
        }

        public DbSet<Lab4Part4.Models.Product> Product { get; set; } = default!;
    }
}
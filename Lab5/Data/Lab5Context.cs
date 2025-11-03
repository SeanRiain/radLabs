using Lab5;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Lab5.Data
{
    public class Lab5Context : DbContext
    {
        public Lab5Context(DbContextOptions<Lab5Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
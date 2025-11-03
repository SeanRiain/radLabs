using Lab5;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        //second class goes here


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FluentUser>().HasKey(u => u.ID);
            modelBuilder.Entity<FluentUser>().Property(u => u.FirstName).HasMaxLength(15).HasColumnName("user_FirstName");
            modelBuilder.Entity<FluentUser>().Property(u => u.LastName).HasMaxLength(15).HasColumnName("user_LastName");
            modelBuilder.Entity<FluentUser>().Property(u => u.LastName).HasMaxLength(15).HasColumnName("user_LastName");
            modelBuilder.Entity<FluentUser>().Property(u => u.Age).HasColumnName("age_of_user");

            modelBuilder.Entity<FluentUserExtension>().HasKey(d => d.FluentUserID);

            modelBuilder.Entity<FluentUser>()
                .HasOne(u => u.Extension)
                .WithOne()
                .HasForeignKey<FluentUserExtension>(d => d.FluentUserID);


           // modelBuilder.Entity<FluentUser>(entityBuilder =>
           // {
           //     entityBuilder
           //     .ToTable("Users")
           //     .SplitToTable(
           //     "Names",
           //     tableBuilder =>
           // {
           //     tableBuilder.Property(user => user.identification);
           //     tableBuilder.Property(user => user.name).HasColumnName("User");
           //     tableBuilder.Property(user => user.age).HasColumnName("age");
           // })
           // .SplitToTable(
           // "Addresses"
           //,
           // tableBuilder =>

           // {
           //  tableBuilder.Property(user =>
           //  user.identification);
           //  tableBuilder.Property(user => user.age);
           // });
           // });
        }
    }
}
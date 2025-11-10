using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Data
{
    public class Lab3Context : DbContext
    {
        public Lab3Context (DbContextOptions<Lab3Context> options)
            : base(options)
        {
        }

        public DbSet<Lab3.Models.Book> Book { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Split Book into Book and BookDetails
            modelBuilder.Entity<Book>()
                .HasOne(book => book.Details)
                .WithOne()
                .HasForeignKey<BookDetails>(bookdetails => bookdetails.BookId);

            //Summary must be at least 50 characters
            modelBuilder.Entity<BookDetails>()
               .Property(book => book.Summary)
               .HasMaxLength(500); //max, not min


            //Custom column names
            modelBuilder.Entity<Book>()
        .Property(book => book.Title)
        .HasColumnName("The Books Title");

            modelBuilder.Entity<Book>()
        .Property(book => book.ReleaseDate)
           .HasColumnName("The Date of Publishing");

            //CoverPage must exist
            modelBuilder.Entity<BookDetails>()
       .Property(bookdetails => bookdetails.CoverPage)
          .IsRequired();
        }

    }
}

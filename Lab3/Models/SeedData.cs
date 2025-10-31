using Lab3.Data;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Lab3.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Lab3Context(
            serviceProvider.GetRequiredService<
                DbContextOptions<Lab3Context>>()))
        {
            // Look for any books.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }
            context.Book.AddRange(
                new Book
                {
                    Title = "Lolita",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,

                    Summary = "nothing good",
                    CoverPage = "stop.jpg",
                    Publisher = "some freak",
                    PublisherID = 14,
                    AuthorID = 13
                },
                new Book
                {
                    Title = "Hostel ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,

                    Summary = "american foriegn policy",
                    CoverPage = "hostel.jpg",
                    Publisher = "CIA.Gov",
                    PublisherID = 1982,
                    AuthorID = 411
                },
                new Book
                {
                    Title = "Come and See",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,

                    Summary = "nothing nice",
                    CoverPage = "come to belarus.png",
                    Publisher = "poland",
                    PublisherID = 1944,
                    AuthorID = 1933
                },
                new Book
                {
                    Title = "Blood Meridian",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,

                    Summary = "american domestic policy",
                    CoverPage = "bald.jpg",
                    Publisher = "FBI.Gov",
                    PublisherID = 1880,
                    AuthorID = 1000
                }
            );
            context.SaveChanges();
        }
    }
}
using Lab4Part2;
//using Lab4Part2.Data;
//using Lab4Part2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Lab4Part2;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new AdsDB(
            serviceProvider.GetRequiredService<
                DbContextOptions<AdsDB>>()))
        {
            // Look for any books.
            if (context.Advertisements.Any())
            {
                return;   // DB has been seeded
            }
            context.Sellers.AddRange(
                new Sellers { SellerName = "Alice" },
                new Sellers { SellerName = "Bob" }
            );

            context.Categories.AddRange(
                new Categories { CategoryName = "Electronics" },
                new Categories { CategoryName = "Furniture" }
            );

            context.Advertisements.AddRange(
                new Ads { Description = "Laptop", Price = 500, SellerID = 1, CategoryID = 1 },
                new Ads { Description = "Chair", Price = 50, SellerID = 2, CategoryID = 2 }
            );

            context.SaveChanges();
        }
    }
}
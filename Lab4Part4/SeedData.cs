using Lab4Part4.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lab4Part4
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Lab4Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Lab4Context>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }
                context.Supplier.AddRange(
                    new Supplier
                    {
                        ID = 1,
                        Name = "Supplier 1",
                        AddressLine1 = "",
                        AddressLine2 = ""
                    },
                    new Supplier
                    {
                        ID = 2,
                        Name = "Supplier 2",
                        AddressLine1 = "",
                        AddressLine2 = ""
                    }
                );

                context.Product.AddRange(
                    new Product
                    {
                        ID = 1,
                        CategoryID = 1,
                        Description = "",
                        UnitPrice = 1f,
                        dateFirstIssued = DateTime.Now,
                        QuantityInStock = 100,
                    },
                    new Product
                    {
                        ID = 2,
                        CategoryID = 2,
                        Description = "",
                        UnitPrice = 1f,
                        dateFirstIssued = DateTime.Now,
                        QuantityInStock = 100,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

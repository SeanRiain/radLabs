using Lab4Part4.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography;

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
                if (context.Product.Any())
                {
                    return;
                }

                Supplier Supplier1 = new Supplier
                {
                    ID = 1,
                    Name = "Supplier 1",
                    AddressLine1 = "",
                    AddressLine2 = ""
                };

                Supplier Supplier2 = new Supplier
                {
                    ID = 2,
                    Name = "Supplier 2",
                    AddressLine1 = "",
                    AddressLine2 = ""
                };

                context.Supplier.AddRange(Supplier1, Supplier2);

                Category Category1 = new Category
                {
                    CategoryID = 1,
                    Description = "",
                };
                Category Category2 = new Category
                {
                    CategoryID = 2,
                    Description = "",
                };

                context.Category.AddRange(Category1, Category2);

                Product Product1 = new Product
                {
                    Description = "",
                    UnitPrice = 1f,
                    dateFirstIssued = DateTime.Now,
                    QuantityInStock = 100,
                };

                Product1.Suppliers.Add(Supplier1);


                Product Product2 = new Product
                {
                    Description = "",
                    UnitPrice = 1f,
                    dateFirstIssued = DateTime.Now,
                    QuantityInStock = 100,
                    Category = Category1,
                };

                Product2.Suppliers.Add(Supplier2);

                context.Product.AddRange(Product1,Product2);

                context.SaveChanges();
            }
        }
    }
}

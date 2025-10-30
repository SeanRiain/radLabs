using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2025_Week1_Lab1
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Description { get; set; }

        public Category(int CategorysID, string CategorysDescription)
        {
            CategoryID = CategorysID;
            Description = CategorysDescription;
        }
        //List<Product> ProductsC;
    }
    public class Product
    {
        public int ProductID;
        public string Description;
        public int QuantityInStock;
        public float UnitPrice;
        public int CategoryID;
        public float TotalValue => QuantityInStock * UnitPrice;


        public Product(int ProductsID, string ProductsDescription, int ProductsQuantity, float ProductsPrice, int ProductsCategory)
        {
             ProductID = ProductsID;
             Description = ProductsDescription;
             QuantityInStock = ProductsQuantity;
             UnitPrice = ProductsPrice;
             CategoryID = ProductsCategory; //FK
        }
        //Category ProductCategory;
        //Supplier ProductSupplier;
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress1 { get; set; }
        public string SupplierAddress2 { get; set; }

        public Supplier(int SuppliersID, string SuppliersName, string SuppliersAddress1, string SuppliersAddress2)
        {
            SupplierID = SuppliersID;
            SupplierName = SuppliersName;
            SupplierAddress1 = SuppliersAddress1;
            SupplierAddress2 = SuppliersAddress2;
        }
        //List<Product> ProductsS;
    }

    public class SupplierProduct
    {
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public DateTime DateFirstSupplied { get; set; }

        public SupplierProduct(int SuppliersID, int ProductsID, DateTime TheDateFirstSupplied)
        {
            SupplierID = SuppliersID;
            ProductID = ProductsID;
            DateFirstSupplied = TheDateFirstSupplied;
        }
    }

    internal class ProductModel
    {
        public static void Main(String[] args)
        {
            //Category ProductCategory;
            //Supplier ProductSupplier;

            List<Supplier> Suppliers = new List<Supplier>();
            List<Product> Products = new List<Product>();
            List<Category> Categories = new List<Category>();
            List<SupplierProduct> SupplierProducts = new List<SupplierProduct>();


            Supplier Supplier1 = new Supplier(1, "ACME", "Collooney", "Sligo");
            Supplier Supplier2 = new Supplier(1, "Swift Electric", "Finglas", "Dublin");

            Product Product1 = new Product(1, "9 Inch Nails", 200, 0.1f, 1);
            Product Product2 = new Product(2, "9 Inch Bolts", 120, 0.2f, 1);
            Product Product3 = new Product(3, "Chimney Hoover", 10, 100.30f, 2);
            Product Product4 = new Product(4, "Washing Machine", 7, 399.50f, 2);

            Category Category1 = new Category(1, "Hardware");
            Category Category2 = new Category(2, "Electrical Appliances");

            SupplierProduct SP1 = new SupplierProduct(1, 1, new DateTime(2012, 12, 12)); //YEAR MONTH DAY
            SupplierProduct SP2 = new SupplierProduct(1, 2, new DateTime(2017, 08, 13)); 
            SupplierProduct SP3 = new SupplierProduct(1, 3, new DateTime(2022, 09, 09));
            SupplierProduct SP4 = new SupplierProduct(1, 4, new DateTime(2024, 04, 11));

            Suppliers.Add(Supplier1); Suppliers.Add(Supplier2);
            Products.Add(Product1); Products.Add(Product2); Products.Add(Product3); Products.Add(Product4);
            Categories.Add(Category1); Categories.Add(Category2);
            SupplierProducts.Add(SP1); SupplierProducts.Add(SP2); SupplierProducts.Add(SP3); SupplierProducts.Add(SP4);

            //LINQ Queries

            //All Categories
            IEnumerable<Category> AllCategories =
            from CategoryInstance in Categories
            //where score > 80
            select CategoryInstance;


            //All Products
            IEnumerable<Product> AllProducts =
            from ProductInstance in Products
            select ProductInstance;


            //Products with a Quantity ≤ 100
            IEnumerable<Product> ProductsUnder100 =
            from ProductInstance in Products
            where ProductInstance.QuantityInStock < 100
            select ProductInstance;
            foreach (Product product in ProductsUnder100)
            {
                Console.WriteLine(product.QuantityInStock);
            }

            //Products with a Quantity ≤ 120
            IEnumerable<Product> ProductsOver120 =
            from ProductInstance in Products
            where ProductInstance.QuantityInStock > 120
            select ProductInstance;
            foreach (Product product in ProductsOver120)
            {
                Console.WriteLine(product.QuantityInStock);
            }

            //Products and their total values
            IEnumerable<Product> ProductValues =
            from ProductValue in Products
            select ProductValue; //This works as totalvalue and the logic needed to calculate it was added to the product class
            Console.WriteLine("Products with Total Value:");
            foreach (var PV in ProductValues)
            {
                Console.WriteLine($"{PV.Description} | Qty: {PV.QuantityInStock} | Price: {PV.UnitPrice:C} | Total: {PV.TotalValue:C}");
            }

            //Products in the Hardware Category
            var HardwareProducts =
            from ProductInstance in Products
            join SingleCategory in Categories on ProductInstance.CategoryID equals SingleCategory.CategoryID
            where SingleCategory.Description == "Hardware"
            select ProductInstance;

            //Products in the Hardware Category, no join
            var HardwareCategoryID =
            (from Category in Categories
             where Category.Description == "Hardware"
             select Category.CategoryID).FirstOrDefault();

                var HardwareProductsFilter =
                from Product in Products
                where Product.CategoryID == HardwareCategoryID //No join needed as this is simply a pre-established var we can compare the CategoryID to
                select Product;

            foreach (var FilteredProduct in HardwareProductsFilter)
            {
                Console.WriteLine($"{FilteredProduct.Description} | Qty: {FilteredProduct.QuantityInStock}");
            }

            //Suppliers and parts ordered by supplier
            var SupplierParts =
            from Supplier in Suppliers
            join SupplierProduct in SupplierProducts on Supplier.SupplierID equals SupplierProduct.SupplierID
            join Product in Products on SupplierProduct.ProductID equals Product.ProductID
            orderby Supplier.SupplierName
            select new {Supplier.SupplierName, Product.Description};

            Console.WriteLine("Suppliers and their Parts:");
            foreach (var SupplierPart in SupplierParts)
            {
                Console.WriteLine($"{SupplierPart.SupplierName} supplies {SupplierPart.Description}");
            }
        }
    }
}
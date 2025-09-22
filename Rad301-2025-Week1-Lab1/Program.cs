using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2025_Week1_Lab1
{
    public class Category
    {
        int CategoryID;
        int Description;

        //List<Product> ProductsC;
    }
    public class Product
    {
        int ProductID;
        string Description;
        int QuantityInStock;
        float UnityPrice;
        int CategoryID;

        public Product(int ProductsID, string ProductsDescription, int ProductsQuantity, float ProductsPrice, int ProductsCategory)
        {
             ProductID = ProductsID;
             Description = ProductsDescription;
             QuantityInStock = ProductsQuantity;
             UnityPrice = ProductsPrice;
             CategoryID = ProductsCategory; //FK
        }
        //Category ProductCategory;
        //Supplier ProductSupplier;
    }

    public class Supplier
    {
        int SupplierID;
        string SupplierName;
        string SupplierAddress1;
        string SupplierAddress2;

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
        int SupplierID;
        int ProductID;
        DateTime DateFirstSupplied;
    }

    internal class ProductModel
    {
        Category ProductCategory;
        Supplier ProductSupplier;

        List<Product> Products;
        List<Supplier> Suppliers;
        List<Category> Categories;

        Supplier Supplier1 = Supplier(1, "ACME", "Collooney", "Sligo");
        Supplier Supplier2 = Supplier(1, "ACME", "Collooney", "Sligo");

        Product Product1 = Product(1, "9 Inch Nails", 200, 0.1, 1);
        Product Product2 = Product(2, "9 Inch Bolts", 120, 0.2, 1);
        Product Product3 = Product(3, "Chimney Hoover", 10, 100.30, 2);
        Product Product4 = Product(4, "Washing Machine", 7, 399.50, 2);

        Category Category1 = Category(1, "Hardware");
        Category Category2 = Category(2, "Electrical Appliances");

        SupplierProduct SP1 = SupplierProduct(1, 1, 12 / 12 / 2012);
        SupplierProduct SP2 = SupplierProduct(1, 2, 13 / 08 / 2017);
        SupplierProduct SP3 = SupplierProduct(1, 3, 09 / 09 / 2022);
        SupplierProduct SP4 = SupplierProduct(1, 4, 11 / 04 / 2024);




    }
}
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
    }
    public class Product
    {
        int ProductID;
        string Description;
        int QuantityInStock;
        float UnityPrice;
        int CategoryID;
    }

    public class Supplier
    {
        int SupplierID;
        string SupplierName;
        string SupplierAddress1;
        string SupplierAddress2;
    }

    public class SupplierProduct
    {
        int SupplierID;
        int ProductID;
        DateTime DateFirstSupplied;
    }

    internal class ProductModel
    { 

    }
}

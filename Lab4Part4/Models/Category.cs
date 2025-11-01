namespace Lab4Part4
{
    public class Category
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        
    }
}

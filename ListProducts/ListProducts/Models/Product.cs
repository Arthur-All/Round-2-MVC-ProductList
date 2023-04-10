namespace ListProducts.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public bool InCart {get; set; }
        public bool IsDeleted { get; set; }
    }
}

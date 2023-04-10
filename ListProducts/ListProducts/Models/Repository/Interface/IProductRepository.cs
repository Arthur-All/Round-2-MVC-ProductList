using ListProducts.Models;

namespace Model.Models.Repository.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int Id);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<IEnumerable<Product>> GetProductByName(string productName);
        Task<IEnumerable<Product>> GetCartProduct();

        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Product product);
        Task<bool> AddInCart(Product product);
    }
}

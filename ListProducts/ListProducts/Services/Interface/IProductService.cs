using ListProducts.Models;

namespace Services.Services.Interface
{
    public interface IProductService
    {
        Task<Product> GetProductById(int Id);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<IEnumerable<Product>> GetProductByName(string productName);
        Task<IEnumerable<Product>> GetCartProduct();

        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int ProductId);
        Task<bool> AddInCart(int ProductId);
    }
}
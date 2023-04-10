using ListProducts.Models;
using Model.Models.Repository.Interface;
using Services.Services.Interface;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        #region Get
        public async Task<Product> GetProductById(int id)
        {
            #region Exception
            if (id <= 0)
            {
                throw new Exception($"Id can't be 0 or less then 0");
            }
            #endregion

            var result = await _repository.GetProductById(id);
            return result;
        }
        public Task<IEnumerable<Product>> GetAllProduct()
        {
            var result = _repository.GetAllProduct();
            return result;
        }
        public Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            #region Exception
            if (productName == null)
            {
                throw new ArgumentNullException("please enter the product name");
            }
            #endregion

            var result = _repository.GetProductByName(productName + "%");
            return result;
        }

        public Task<IEnumerable<Product>> GetCartProduct()
        {
            var result = _repository.GetCartProduct();
            return result;
        }
        #endregion

        #region Create, Update,Delete
        public Task<bool> CreateProduct(Product product)
        {
            #region Exceptions
            if (product.Name == null)
            {
                throw new ArgumentNullException("please enter the product name");
            }
            if (product.Price == 0)
            {
                throw new ArgumentNullException("please enter the product price");
            }
            #endregion

            var result = _repository.CreateProduct(product);
            return result;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _repository.UpdateProduct(product);
            return result;
        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            var product = await GetProductById(ProductId);

            product.IsDeleted = true;

            var success = await _repository.DeleteProduct(product);

            return success;
        }

        public async Task<bool> AddInCart(int ProductId)
        {
            var product = await GetProductById(ProductId);

            product.InCart = true;

            var success = await _repository.AddInCart(product);

            return success;
        }
        #endregion
    }
}

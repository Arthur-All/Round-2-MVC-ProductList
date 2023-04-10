using Dapper;
using ListProducts.Models;
using Microsoft.Extensions.Configuration;
using Model.Models.Context;
using Model.Models.Repository.Interface;
using System.Data;

namespace Model.Models.Repository
{
    public class ProductRepository : IProductRepository
    {

        #region Dapper
        private const string GetId = @"SELECT * FROM products WHERE id = @id";
        private const string GetAll = @"SELECT * FROM products where IsDeleted = 0 and InCart = 0";
        private const string GetByName = @"SELECT name FROM products WHERE name like @productName";
        private const string GetCart = @"SELECT * FROM products WHERE InCart = 1 and IsDeleted = 0";
        #endregion

        private readonly IDbConnection _connection;
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connection = _connection.AddConnection(configuration);
        }

        #region Get
        public async Task<Product> GetProductById(int id)
        {
            return await _connection.QueryFirstOrDefaultAsync<Product>(GetId, new { id });
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            var result = await _connection.QueryAsync<Product>(GetAll);

            return result;
        }

        public async Task<IEnumerable<Product>> GetCartProduct()
        {
            return await _connection.QueryAsync<Product>(GetCart);
        }

        public async Task<IEnumerable<Product>> GetProductByName(string productName)
        {
            return await _connection.QueryAsync<Product>(GetByName, new { productName });
        }
        #endregion

        #region Create, Update, Delete
        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Update(product);
            var success = await _context.SaveChangesAsync() > 0;
            return success;
        }

        public async Task<bool> CreateProduct(Product product)
        {
            _context.Add(product);
            var success = await _context.SaveChangesAsync() > 0;
            return success;
        }
        public async Task<bool> AddInCart(Product product)
        {
            _context.Update(product);
            var success = await _context.SaveChangesAsync() > 0;
            return success;
        }
        public async Task<bool> DeleteProduct(Product product)
        {
            _context.Update(product);
            var success = await _context.SaveChangesAsync() > 0;
            return success;
        }
        #endregion
    }
}

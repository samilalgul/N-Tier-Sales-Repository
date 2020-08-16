using Sales.Entities;
using Sales.Entities.Interfaces;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BLL
{
    public class ProductService : IProductService
    {
        public Task<Product> CreateProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            throw new NotImplementedException();
        }
    }
}

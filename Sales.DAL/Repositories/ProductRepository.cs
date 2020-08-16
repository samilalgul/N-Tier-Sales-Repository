using Microsoft.EntityFrameworkCore;
using Sales.Entities.Models;
using Sales.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private SalesDbContext SalesDbContext
        {
            get { return Context as SalesDbContext; }
        }
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllWithSalesAsync()
        {
            return await SalesDbContext.Products
                .Include(p => p.Sales)
                .ToListAsync();
        }

        public Task<Product> GetWithSalesByIdAsync(int id)
        {
            return SalesDbContext.Products
                .Include(p => p.Sales)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        async Task<IEnumerable<Product>> IProductRepository.GetAllWithSalesAsync()
        {
            return await SalesDbContext.Products
                .Include(p => p.Sales)
                .ToListAsync();
        }

        Task<Product> IProductRepository.GetWithSalesByIdAsync(int id)
        {
            return SalesDbContext.Products
                .Include(p => p.Sales)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}

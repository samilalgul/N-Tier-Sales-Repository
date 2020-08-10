using Microsoft.EntityFrameworkCore;
using Sales.Entities.Models;
using Sales.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private SalesDbContext SalesDbContext
        {
            get { return Context as SalesDbContext; }
        }
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllWithSalessAsync()
        {
            return await SalesDbContext.Customers
                .Include(c => c.Sales)
                .ToListAsync();
        }

        public Task<Customer> GetWithSaleByIdAsync(int id)
        {
            return SalesDbContext.Customers
                .Include(c => c.Sales)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        async Task<IEnumerable<Customer>> ICustomerRepository.GetAllWithSalesAsync()
        {
            return await SalesDbContext.Customers
                .Include(c => c.Sales)
                .ToListAsync();
        }

        Task<Customer> ICustomerRepository.GetWithSalesByIdAsync(int id)
        {
            return SalesDbContext.Customers
                .Include(c => c.Sales)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}

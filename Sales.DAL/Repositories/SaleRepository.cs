using Microsoft.EntityFrameworkCore;
using Sales.Entities.Models;
using Sales.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private SalesDbContext SalesDbContext
        {
            get { return Context as SalesDbContext; }
        }
        public SaleRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sale>> GetAllWithCustomerAsync()
        {
            return await SalesDbContext.Sales
                .Include(s => s.Customer)
                .ToListAsync();
        }

        public async Task<Sale> GetWithCustomerByIdAsync(int id)
        {
            return await SalesDbContext.Sales
                .Include(s => s.Customer)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Sale>> GetAllWithArtistByCustomerIdAsync(int customerId)
        {
            return await SalesDbContext.Sales
                .Include(s => s.Customer)
                .Where(s => s.CustomerId == customerId)
                .ToListAsync();
        }

        async Task<IEnumerable<Sale>> ISaleRepository.GetAllWithCustomerAsync()
        {
            return await SalesDbContext.Sales
                .Include(s => s.Customer)
                .ToListAsync();
        }

        async Task<Sale> ISaleRepository.GetWithCustomerByIdAsync(int id)
        {
            return await SalesDbContext.Sales
                .Include(s => s.Customer)
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        async Task<IEnumerable<Sale>> ISaleRepository.GetAllWithCustomerByCustomertIdAsync(int customerId)
        {
            return await SalesDbContext.Sales
                .Include(s => s.Customer)
                .Where(s => s.CustomerId == customerId)
                .ToListAsync();
        }
    }
}

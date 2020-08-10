using Sales.DAL.Repositories;
using Sales.Entities;
using Sales.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SalesDbContext salesDbContext;
        private ISaleRepository saleRepository;
        private ICustomerRepository customerRepository;
        private IUserRepository userRepository;

        public UnitOfWork(SalesDbContext salesDbContext)
        {
            this.salesDbContext = salesDbContext;
        }

        public ISaleRepository Sales => saleRepository = saleRepository ?? new SaleRepository(salesDbContext);

        public ICustomerRepository Customers => customerRepository = customerRepository ?? new CustomerRepository(salesDbContext);

        public IUserRepository Users => userRepository = userRepository ?? new UserRepository(salesDbContext);

        public async Task<int> CommitAsync()
        {
            return await salesDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            salesDbContext.Dispose();
        }
    }
}

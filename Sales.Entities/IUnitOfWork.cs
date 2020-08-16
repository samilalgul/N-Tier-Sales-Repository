using Sales.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities
{
    public interface IUnitOfWork : IDisposable
    {
        ISaleRepository Sales { get; }
        ICustomerRepository Customers { get; }
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        Task<int> CommitAsync();
    }
}

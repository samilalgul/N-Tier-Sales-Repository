using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Repositories
{
    public interface ICustomerRepository :IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithSalesAsync();
        Task<Customer> GetWithSalesByIdAsync(int id);

    }
}

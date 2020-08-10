using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Repositories
{
    public interface ISaleRepository: IRepository<Sale>
    {
        Task<IEnumerable<Sale>> GetAllWithCustomerAsync();
        Task<Sale> GetWithCustomerByIdAsync(int id);
        Task<IEnumerable<Sale>> GetAllWithCustomerByCustomertIdAsync(int customerId);
    }
}

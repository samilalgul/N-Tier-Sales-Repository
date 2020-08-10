using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Interfaces
{
    // Center of bussines logic
    // The connection between api and dal
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllWithCustomer();
        Task<Sale> GetSaleById(int id);
        Task<IEnumerable<Sale>> GetSaleByCustomerId(int customerId);
        Task<Sale> CreateSale(Sale newSale);
        Task UpdateSale(Sale saleToBeUpdated, Sale sale);
        Task DeleteSale(Sale sale);
    }
}

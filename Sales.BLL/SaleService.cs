using Sales.Entities;
using Sales.Entities.Interfaces;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BLL
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SaleService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Sale> CreateSale(Sale newSale)
        {
            await _unitOfWork.Sales.AddAsync(newSale);
            await _unitOfWork.CommitAsync();
            return newSale;
        }

        public async Task DeleteSale(Sale sale)
        {
            _unitOfWork.Sales.Remove(sale);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Sale>> GetAllWithCustomer()
        {
            return await _unitOfWork.Sales
                .GetAllWithCustomerAsync();
        }

        public async Task<IEnumerable<Sale>> GetSaleByCustomerId(int customerId)
        {
            return await _unitOfWork.Sales.GetAllWithCustomerByCustomertIdAsync(customerId);
        }

        public async Task<Sale> GetSaleById(int id)
        {
            return await _unitOfWork.Sales
                .GetByIdAsync(id);
        }

        public async Task UpdateSale(Sale saleToBeUpdated, Sale sale)
        {
            saleToBeUpdated.SoldProducts = sale.SoldProducts;
            saleToBeUpdated.CustomerId = sale.CustomerId;

            await _unitOfWork.CommitAsync();
        }
    }
}

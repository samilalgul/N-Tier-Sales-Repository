using Sales.Entities;
using Sales.Entities.Interfaces;
using Sales.Entities.Models;
using Sales.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.BLL
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork )
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Customer> CreateCustomer(Customer newCustomer)
        {
            await _unitOfWork.Customers
              .AddAsync(newCustomer);
            await _unitOfWork.CommitAsync();
            //await _customerRepository.Customers
              //  .AddAsync(newCustomer);
            //await _customerRepository.CommitAsync();

            return newCustomer;
        }

        public async Task DeleteCustomer(Customer customer)
        {
            //??
            _unitOfWork.Customers.Remove(customer);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _unitOfWork.Customers.GetAllAsync();
            //return await _customerRepository.GetAllAsync();

        }

        public async Task<Customer> GetCustomertById(int id)
        {
            //return await _unitOfWork.Customers.GetByIdAsync(id);
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }

        public async Task UpdateCustomer(Customer customerToBeUpdated, Customer customer)
        {
            customerToBeUpdated.Name = customer.Name;

            await _unitOfWork.CommitAsync();
        }
        public async Task<IEnumerable<Customer>> GetAllWithSales()
        {
            return await _unitOfWork.Customers.GetAllWithSalesAsync();
            //return await _customerRepository.GetAllWithSalesAsync();

        }
    }
}

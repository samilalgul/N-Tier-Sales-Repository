using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomertById(int id);
        Task<Customer> CreateCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer customerToBeUpdated, Customer customer);
        Task DeleteCustomer(Customer customer);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.API.DTOs;
using Sales.API.Validators;
using Sales.Entities.Interfaces;
using Sales.Entities.Models;
using Sales.Entities.Logger;

namespace Sales.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper )
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllCustomers()
        {
            Logger.Log("GetAllCustomer Method Log Msg");
            var customers = await _customerService.GetAllCustomers();
            var customerDTO = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customers);
            return Ok(customerDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomertById(id);
            if(customer == null)
            {
                return NotFound();
            }
            var customerDTO = _mapper.Map<Customer, CustomerDTO>(customer);
            return Ok(customerDTO);
        }
        [HttpPost("")]
        public async Task<ActionResult<CustomerDTO>> CreateCstomer([FromBody] CUDCustomerDTO cUDCustomerDTO)
        {
            var validation = new CUDCustomerValidator();

            var validationResult = await validation.ValidateAsync(cUDCustomerDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var customer = _mapper.Map<CUDCustomerDTO, Customer>(cUDCustomerDTO);

            var newCustomer = await _customerService.CreateCustomer(customer);

            var customerCreated = await _customerService.GetCustomertById(newCustomer.Id);

            var customerDTO = _mapper.Map<Customer, CustomerDTO>(customerCreated);

            return Ok(customerDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDTO>> UpdateCustomer(int id, [FromBody] CUDCustomerDTO cUDCustomerDTO)
        {
            var validation = new CUDCustomerValidator();
            var validationResult = await validation.ValidateAsync(cUDCustomerDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var customerToUpdate = await _customerService.GetCustomertById(id);

            if (customerToUpdate == null)
            {
                return NotFound();
            }
            var customer = _mapper.Map<CUDCustomerDTO, Customer>(cUDCustomerDTO);

            await _customerService.UpdateCustomer(customerToUpdate, customer);

            var customerUpdated = await _customerService.GetCustomertById(id);

            var customerDTO = _mapper.Map<Customer, CustomerDTO>(customerUpdated);
            return Ok(customerDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomertById(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _customerService.DeleteCustomer(customer);

            return NoContent();
        }


    }
}

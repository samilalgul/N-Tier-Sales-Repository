using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.API.DTOs;
using Sales.API.Validators;
using Sales.Entities.Interfaces;
using Sales.Entities.Models;

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public SaleController(ISaleService saleService, IMapper mapper, ICustomerService customerService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _saleService = saleService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetAllSales()
        {
            var sales = await _saleService.GetAllWithCustomer();
            var salesDTO = _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(sales);
            return Ok(salesDTO);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDTO>> GetSaleById(int id)
        {
            var sale = await _saleService.GetSaleById(id);
            if(sale == null)
            {
                return NotFound();
            }
            var saleDTO = _mapper.Map<Sale, SaleDTO>(sale);
            return Ok(saleDTO);
        }
        [HttpPost("")]
        public async Task<ActionResult<SaleDTO>> CreateSale([FromBody] CUDSaleDTO cUDSaleDTO)
        {
            var validatorSale = new CUDSaleValidator();
            var validationResult = await validatorSale.ValidateAsync(cUDSaleDTO);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var sale = _mapper.Map<CUDSaleDTO, Sale>(cUDSaleDTO);
            var newSale = await _saleService.CreateSale(sale);
            return Ok(newSale);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<SaleDTO>> UpdateSale(int id, [FromBody] CUDSaleDTO updateCUDDTO)
        {
            var validator = new CUDSaleValidator();
            var resultValidator = await validator.ValidateAsync(updateCUDDTO);
            if (!resultValidator.IsValid)
            {
                return BadRequest(resultValidator.Errors);
            }
            var saleToBeUpdate = await _saleService.GetSaleById(id);
            if(saleToBeUpdate == null)
            {
                return NotFound();
            }
            var saleUpdate = _mapper.Map<CUDSaleDTO, Sale>(updateCUDDTO);
            await _saleService.UpdateSale(saleToBeUpdate, saleUpdate);

            var newSaleUpdate = await _saleService.GetSaleById(id);
            var saleUpdateDTO = _mapper.Map<Sale, SaleDTO>(newSaleUpdate);
            return Ok(saleUpdateDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            var sale = await _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }
            await _saleService.DeleteSale(sale);

            return NoContent();

        }

        [HttpGet("Customer/id")]
        public async Task<ActionResult<IEnumerable<SaleDTO>>> GetAllSalesByCustomerID(int id)
        {
            var artist = await _customerService.GetCustomertById(id);
            if (artist == null)
            {
                return NotFound();
            }
            var sales = await _saleService.GetSaleByCustomerId(id);
            var saleDTO = _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(sales);
            return Ok(saleDTO);

        }
    }
}

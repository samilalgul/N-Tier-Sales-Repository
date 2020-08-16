using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sales.API.DTOs;
using Sales.API.Validators;
using Sales.Entities.Interfaces;
using Sales.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<controller>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var product = await _productService.GetAllProducts();
            var productDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(product);
            return Ok(productDTO);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }
            var productDTO = _mapper.Map<Product, ProductDTO>(product);
            return Ok(productDTO);
        }

        // POST api/<controller>
        [HttpPost("")]
        public async Task<ActionResult<CustomerDTO>> CreateProduct([FromBody] CUDProductDTO cUDProductDTO)
        {
            var validation = new CUDProductDTOValidator();

            var validationResult = await validation.ValidateAsync(cUDProductDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var product = _mapper.Map<CUDProductDTO, Product>(cUDProductDTO);

            var newProduct = await _productService.CreateProduct(product);

            var productCreated = await _productService.GetProductById(newProduct.Id);

            var productDTO = _mapper.Map<Product, ProductDTO>(productCreated);

            return Ok(productDTO);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(int id, [FromBody] CUDProductDTO cUDProductDTO)
        {
            var validation = new CUDProductDTOValidator();
            var validationResult = await validation.ValidateAsync(cUDProductDTO);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var productToUpdate = await _productService.GetProductById(id);

            if (productToUpdate == null)
            {
                return NotFound();
            }
            var product = _mapper.Map<CUDProductDTO, Product>(cUDProductDTO);

            await _productService.UpdateProduct(productToUpdate, product);

            var productUpdated = await _productService.GetProductById(id);

            var productDTO = _mapper.Map<Product, ProductDTO>(productUpdated);
            return Ok(productDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.DeleteProduct(product);

            return NoContent();
        }


    }
}

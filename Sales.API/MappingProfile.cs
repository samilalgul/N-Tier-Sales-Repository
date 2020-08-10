using AutoMapper;
using Sales.API.Controllers;
using Sales.API.DTOs;
using Sales.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Sale, SaleDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Customer, CUDSaleDTO>();
            CreateMap<Sale, CUDSaleDTO>();
            CreateMap<User, UserDTO>();

            CreateMap<SaleDTO, Sale>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<CUDSaleDTO, Sale>();
            CreateMap<CUDCustomerDTO, Customer>();
            CreateMap<UserDTO, User>();
        }
    }
}

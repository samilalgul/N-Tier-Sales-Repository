using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.DTOs
{
    public class CUDSaleDTO
    {
        public string SoldProducts { get; set; }
        public int CustomerId { get; set; }
    }
}

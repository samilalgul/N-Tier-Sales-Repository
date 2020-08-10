using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.DTOs
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public string SoldPoducts { get; set; }

        public CustomerDTO Customer { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Entities.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public string SoldProducts { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}

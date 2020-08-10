using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sales.Entities.Models
{
    public class Customer
    {
        public Customer()
        {
            Sales = new Collection<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}

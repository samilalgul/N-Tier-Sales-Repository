using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sales.Entities.Models
{
    [Table("Customers")]
    public class Customer
    {
        public Customer()
        {
            Sales = new Collection<Sale>();
        }
        [Key]
        public int Id { get; set; }

        [MaxLength(50), MinLength(2)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50), MinLength(2)]
        [Required]
        public string Surname { get; set; }

        public string Company { get; set; }

        [Phone]
        public string Phone { get; set; }

        public string Email { get; set; }

        public string ExactAdress { get; set; }

        public string Location { get; set; }

        public string City { get; set; }
        
        public ICollection<Sale> Sales { get; set; }
    }
}

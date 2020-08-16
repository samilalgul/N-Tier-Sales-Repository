using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sales.Entities.Models
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string SoldProducts { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}

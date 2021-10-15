using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpdatePustokMVC.Models
{
    public class ProductImg
    {
        public int Id { get; set; }
      
        [StringLength(maximumLength: 120)]
        public string Name { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}

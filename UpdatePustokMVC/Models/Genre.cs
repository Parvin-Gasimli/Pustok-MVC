using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UpdatePustokMVC.Models
{
    public class Genre
    {
        public int Id { get; set; }
    
        [StringLength(maximumLength: 120)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

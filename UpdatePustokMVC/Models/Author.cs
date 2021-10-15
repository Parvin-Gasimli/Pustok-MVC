using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UpdatePustokMVC.Models
{
    public class Author
    {
        public int Id { get; set; }
     
        [StringLength(maximumLength:120)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}

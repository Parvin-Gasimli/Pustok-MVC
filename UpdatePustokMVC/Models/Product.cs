using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UpdatePustokMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:120)]
        public string Name { get; set; }
        [StringLength(maximumLength: 220)]
        public string Title { get; set; }
        [StringLength(maximumLength: 100)]
        public string Images { get; set; }
        [StringLength(maximumLength: 100)]
        public string HovImages { get; set; }
        [Column(TypeName ="money")]
        public double? Price { get; set; }
        [Column(TypeName = "money")]
        public double? Discountprice { get; set; }
        public bool IsFeature { get; set; }
        public bool IsArrival { get; set; }
        public bool IsMost { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public  double ? eXTax { get; set; }
     [StringLength(maximumLength:300)]
     public string Description { get; set; }
        public string Code { get; set; }
        public int Point { get; set; }
        public bool IsAvabilty { get; set; }
        public int Star { get; set; }

        public int ? AuthorId { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public int ? GenreId { get; set; }
        public ICollection<ProductImg> ProductImgs { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UpdatePustokMVC.Models
{
    public class IconData
    {
        public int Id { get; set; }
        public string Icons { get; set; }
        [StringLength(maximumLength:150)]

        public string text { get; set; }
        public double Price { get; set; }
    }
}

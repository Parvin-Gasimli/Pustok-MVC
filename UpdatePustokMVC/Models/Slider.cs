using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace UpdatePustokMVC.Models

{
    public class Slider
    {

        public int Id { get; set; }
        [StringLength(maximumLength:155)]
        public string  Images { get; set; }
        [StringLength(maximumLength: 155)]
        public string OriginaLImages { get; set; }
        public string Desc { get; set; }
        [StringLength(maximumLength: 155)]
        [DataType(DataType.Text)]
        public string Text { get; set; }
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public int Order { get; set; }

        public bool  IsDelete { get; set; }
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile File { get; set; }

      

    }
}

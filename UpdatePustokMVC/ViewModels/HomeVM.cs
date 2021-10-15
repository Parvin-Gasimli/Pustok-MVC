using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.Models;

namespace UpdatePustokMVC.ViewModels
{
    public class HomeVM
    {
        public ICollection<Slider> Sliders { get; set; }
        public ICollection<IconData> IconDatas { get; set; }
        public List<Promotion> Promotions { get; set; }
        public ICollection<Product> feature { get; set; }
        public ICollection<Product> Arrival { get; set; }
        public ICollection<Product> Most { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<ProductImg> ProductImgs { get; set; }
        
    }
}

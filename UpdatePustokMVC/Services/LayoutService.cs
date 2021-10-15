using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.ViewModels.BasketProduct;

namespace UpdatePustokMVC.Services
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContext;

        public LayoutService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public ICollection<BasketVM> GetBasket()
        {
            string strBasket = _httpContext.HttpContext.Request.Cookies["basket"];

            List<BasketVM> products = null;

            if (strBasket == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(strBasket);
            }
            return products;
        }
    }
}

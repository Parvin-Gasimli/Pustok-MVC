using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.DAL;
using UpdatePustokMVC.ViewModels;

namespace UpdatePustokMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //HttpContext.Session.SetString("test", "hi guy");

            //return Content(HttpContext.Session.GetString("test"));

            //HttpContext.Response.Cookies.Append("Hello", "helloCooki", new CookieOptions { MaxAge = TimeSpan.FromMinutes(20) });


            //return Content(HttpContext.Request.Cookies["Hello"]);

            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.Where(x=>x.IsDelete==false).OrderBy(x=>x.Order).ToListAsync(),
                IconDatas=await _context.IconDatas.ToListAsync(),
                Promotions=await _context.promotions.ToListAsync(),
                feature =await _context.Products.Include(x=>x.Author).Include(x=>x.Genre).OrderByDescending(x=>x.Id).Where(x=>x.IsFeature).Take(6).ToListAsync(),
                Arrival = await _context.Products.Include(x => x.Author).Include(x => x.Genre).OrderByDescending(x => x.Id).Where(x=>x.IsArrival).Take(6).ToListAsync(),
                Most = await _context.Products.Include(x => x.Author).Include(x => x.Genre).OrderByDescending(x => x.Id).Where(x=>x.IsMost).Take(6).ToListAsync(),
            };
            return View(homeVM);
        }
    }
}

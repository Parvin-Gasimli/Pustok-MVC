using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using UpdatePustokMVC.ViewModels.BasketProduct;
using UpdatePustokMVC.Models;
using UpdatePustokMVC.DAL;

namespace Pustok.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetDetail(int? Id)
        {
            if (Id == null)
                return NotFound();

            //if (!await _context.Products.AnyAsync(p=>p.Id == Id))
            //    return NotFound();

            Product product = await _context.Products
                .Include(p => p.Author)
                .Include(p => p.Genre)
                .Include(p => p.ProductImgs)
                .FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
                return NotFound();

            return PartialView("_ModalPartial", product);

            //return Json(product);
        }

        public async Task<IActionResult> AddBasket(int? Id)
        {
            if (Id == null)
                return NotFound();

            Product product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
                return NotFound();

            string strBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> products = null;

            if (strBasket == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(strBasket);
            }

            BasketVM basketVM = new BasketVM
            {
                Id = (int)Id,
                Title = product.Title,
                MainImage = product.Images,
                Price = product.Discountprice != null ? (double)product.Discountprice : (double)product.Price,
                Count = 1
            };

            if (products.Any(p => p.Id == Id))
            {
                products.FirstOrDefault(p => p.Id == Id).Count += 1;
            }
            else
            {
                products.Add(basketVM);
            }

            string strProduct = JsonConvert.SerializeObject(products);

            HttpContext.Response.Cookies.Append("basket", strProduct, new CookieOptions { MaxAge = TimeSpan.FromMinutes(10) });


            //List<Product> products = new List<Product>();
            //products.Add(product);



            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ShowBasket()
        {
            string strBasket = HttpContext.Request.Cookies["basket"];

            List<BasketVM> products = null;

            if (strBasket == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(strBasket);
            }
            return Json(products);
        }

        //public IActionResult DeleteBook(int? id)
        //{
            

        //    Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
        //    BasketVM basketItem = null;
        //    if (product == null) return NotFound();

        //    AppUser member = null;

          
        //    }

        //    List<BasketVM> books = new List<BasketVM>();

        //    if (member == null)
        //    {

        //        string booksStr = HttpContext.Request.Cookies["Books"];
        //        books = JsonConvert.DeserializeObject<List<BasketVM>>(booksStr);

        //        basketItem = books.FirstOrDefault(x => x.BookId == id);


        //        if (basketItem.Count == 1)
        //        {

        //            books.Remove(basketItem);
        //        }
        //        else
        //        {
        //            basketItem.Count--;
        //        }
        //        booksStr = JsonConvert.SerializeObject(books);
        //        HttpContext.Response.Cookies.Append("Books", booksStr);
        //    }

        //    else
        //    {
        //        BasketItem memberBasketItem = _context.BasketItems.Include(x => x.Book).FirstOrDefault(x => x.AppUserId == member.Id && x.BookId == id);

        //        if (memberBasketItem.Count == 1)
        //        {

        //            _context.BasketItems.Remove(memberBasketItem);
        //        }
        //        else
        //        {
        //            memberBasketItem.Count--;
        //        }

        //        _context.SaveChanges();

        //        books = _context.BasketItems.Include(x => x.Book).ThenInclude(bi => bi.BookImages).Where(x => x.AppUserId == member.Id)
        //            .Select(x => new BasketItemViewModel { BookId = x.BookId, Count = x.Count, Name = x.Book.Name, Price = x.Book.SalePrice - x.Book.DiscountPrice, Image = x.Book.BookImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

        //    }
        //  return PartialView("_ModalPartial", product);
        //}

       

        
       







      









    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.DAL;
using UpdatePustokMVC.Models;

namespace UpdatePustokMVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class AuthorController : Controller
    {
        private readonly AppDbContext _context;
     
        public AuthorController(AppDbContext context)
        {
            _context = context;
       
        }
        public IActionResult Index()
        {
            ICollection<Author> authors = _context.Authors.Include(x => x.Products).ToList();
            return View(authors);
        }
        public IActionResult Details()
        {
            ICollection<Product> books = _context.Products.ToList();
            return View(books);
        }

       

        public async Task<IActionResult> Edit(int? id)
        {
           
            Author author =await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
            if (author == null) return NotFound();
            return View(author);
        }

        [HttpPost]
        public  async Task<IActionResult> Edit(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View(author);
            }
            Author existAuthor =await _context.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);

            if (existAuthor == null) return NotFound();
            existAuthor.Name = author.Name;
           await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int? id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (author == null) return NotFound();

            return View(author);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
           
            Author author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);

            if (author == null) return NotFound();

            _context.Authors.Remove(author);
           await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.DAL;
using UpdatePustokMVC.Models;

namespace UpdatePustokMVC.Areas.manage.Controllers
{    [Area("manage")]
    public class GenreController : Controller
    {
        private readonly AppDbContext _context;
        public GenreController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.Where(g=>g.IsDeleted==false).ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int? Id)
        {
            if (Id == null) return View("Error404");
            Genre genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == Id&&g.IsDeleted==false);
            if (genre == null) return View("Error404");
            return View(genre);
        }
        [HttpGet]
        public async Task<IActionResult>Update(int ? Id)
        {
            if (Id == null) return View("Error404");
            Genre genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == Id);
            if (genre == null) return View("Error404");
            return View(genre);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(int? Id,Genre genre)
        {
            if (Id == null) return View("Error404");
            if (!ModelState.IsValid)
            {
                return View(genre);
            }
        

            if (await _context.Genres.AnyAsync(g => g.Id != Id && g.Name.ToLower() == genre.Name.ToLower() &&g.IsDeleted==false))
            {
                ModelState.AddModelError("Name", "Bu adda mehsul artiq movcuddur");
                return View(genre);
            }
             

            Genre Exgenre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == Id);
         
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
      
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre genre)
        {
            if (!ModelState.IsValid)
                return View(genre);
            if (await _context.Genres.AnyAsync(g => g.Name.ToLower() == genre.Name.ToLower()))
            {
                ModelState.AddModelError("Name", $"{genre.Name} adda genre artiq movcuddur");
                return View(genre);
            }
            await _context.Genres.AddAsync(genre);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");          
        }
       

        [HttpGet]
        public async Task<IActionResult> Delete(int ?Id)
        {
            if (Id == null)
                
           return View("Error404");
            Genre genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == Id && g.IsDeleted == false);
            if (genre == null)
            return View("Error404");
            genre.IsDeleted = true;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");




        }
     
     



    }
}

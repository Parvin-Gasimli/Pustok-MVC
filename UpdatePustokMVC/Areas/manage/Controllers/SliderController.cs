using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.DAL;
using UpdatePustokMVC.Extentions;
using UpdatePustokMVC.Models;

namespace UpdatePustokMVC.Areas.manage.Controllers
{
    [Area("manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _cotext;
        private readonly IWebHostEnvironment _env;
      
        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _cotext = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _cotext.Sliders.Where(x=>x.IsDelete==false).ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {        
            if (!ModelState.IsValid) return View(slider);

            if (!slider.File.ContentType.Contains("image"))
            {
              
                ModelState.AddModelError("File", "Duzgun file Sec!!");
                return View(slider);
            }
            if((slider.File.Length / 1024) > 350)
            {
                ModelState.AddModelError("File", "Duzgun Olcude File daxil edin");
                return View(slider);
            }



            slider.OriginaLImages = slider.File.FileName;

            string path = _env.WebRootPath;
            //string filepath =path+@"\image\bg-images" + slider.File.FileName;
            string fileName=DateTime.Now.ToString("yyyyMMddHHmmss")+"_"+Guid.NewGuid() +"_"+slider.File.FileName;
            slider.Images = fileName;
            string filepath = Path.Combine(path, "image", "bg-images",fileName);


            using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
            {
                await slider.File.CopyToAsync(fileStream);
            }
            await _cotext.Sliders.AddAsync(slider);
            await _cotext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Detail (int ? Id)
        {
            if (Id == null) return NotFound("Error404");

            Slider slider = await _cotext.Sliders.FirstOrDefaultAsync(g => g.Id == Id);
            if (slider == null) return NotFound("Error404");

            return View(slider);
        }
        [HttpGet]
        public async Task<IActionResult> Delete (int ? Id)
        {
            if (Id == null) return NotFound("Error404");
            Slider slider = await _cotext.Sliders.FirstOrDefaultAsync(x => x.Id == Id && x.IsDelete==false );
            if (slider == null) return NotFound("Error404");

            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int ? Id,Slider slider)
        {
            if (Id == null) return NotFound("Error404");
            Slider Delslider = await _cotext.Sliders.FirstOrDefaultAsync(x => x.Id == Id);
            if (slider == null) return NotFound("Error404");
            string filepath = _env.WebRootPath;
            string path = Path.Combine(filepath, "image", "bg-images", Delslider.Images);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Exists(path);
            }
            Delslider.IsDelete = true;
            await _cotext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int ? Id)
        {
            if (Id == null) return NotFound("Error404");
            Slider slider = await _cotext.Sliders.FirstOrDefaultAsync(x => x.Id == Id && x.IsDelete ==false); ;
              if (slider == null) return NotFound("Error404");
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(int? Id,Slider slider)
        {
            if (Id == null)
                return NotFound("Error404");


            if (!ModelState.IsValid)
            {
                return View(slider);
            }

            Slider slider1 = await _cotext.Sliders.FirstOrDefaultAsync(g => g.Id == Id);
            if (slider1 == null)

                return NotFound("Error404");

            if (slider.File != null)
            {
                if (slider.File.CheckContentType("image")) ;
                {

                    ModelState.AddModelError("File", "Duzgun file Sec!!");
                    return View(slider);
                }
                if (slider.File.CheckLength(320)) ;
                {
                    ModelState.AddModelError("File", "Duzgun Olcude File daxil edin");
                    return View(slider);
                }



                slider1.OriginaLImages = slider.File.FileName;

                string path = _env.WebRootPath;
              

                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + Guid.NewGuid() + "_" + slider.File.FileName;

                string Oldfilepath = Path.Combine(path, "image", "bg-images", slider1.Images);

                string filepath = Path.Combine(path, "image", "bg-images", fileName);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Exists(path);
                }

                slider1.Images = fileName;

                using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
                {
                    await slider.File.CopyToAsync(fileStream);
                }

            }
            slider1.Order = slider.Order;
            slider1.Price = slider.Price;
            slider1.Text = slider.Text;
            slider1.Desc = slider.Desc;
            await _cotext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}

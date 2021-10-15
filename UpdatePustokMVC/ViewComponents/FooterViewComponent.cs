using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpdatePustokMVC.DAL;
using UpdatePustokMVC.Models;

namespace UpdatePustokMVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Settings settings = await _context.Settings.FirstOrDefaultAsync();
            return View(await Task.FromResult(settings));
        }
       
    }
   
}

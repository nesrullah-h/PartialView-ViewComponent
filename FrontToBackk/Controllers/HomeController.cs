using FrontToBackk.DAL;
using FrontToBackk.Models;
using FrontToBackk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FrontToBackk.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
              _context = context;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM();
            homeVM.sliders = _context.Sliders.ToList();
            homeVM.pageIntro= _context.PageIntros.FirstOrDefault();
            homeVM.products=_context.Products.Include(p=>p.Category).ToList();
            homeVM.categories=_context.Categories.ToList();

            return View(homeVM);

        }
    }
}

using FrontToBackk.DAL;
using FrontToBackk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBackk.ViewComponents
{
    public class ProductsViewComponent:ViewComponent
    {
        private AppDbContext _context;
        public ProductsViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = _context.Products.Include(products => products.Category).Take(8).ToList();
            return View(await Task.FromResult(products));
        }
    }
}

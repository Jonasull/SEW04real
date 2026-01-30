using Microsoft.AspNetCore.Mvc;
using SEW_oderso_CRUD.Data;
using SEW_oderso_CRUD.Models;

namespace SEW_oderso_CRUD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
            _context.Products.Add(new Product() { Name = "PC", Price = 1000 });
            _context.Products.Add(new Product() { Name = "Radl", Price = 1200 });
            _context.SaveChanges();
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }
    }
}

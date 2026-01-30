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

        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public IActionResult Delete(int id)
        {
            Product? product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);

        }
    }
}

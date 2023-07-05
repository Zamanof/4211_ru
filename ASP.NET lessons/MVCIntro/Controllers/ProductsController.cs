using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCIntro.Data;
using MVCIntro.Models;

namespace MVCIntro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly WebAppMVCContext _context;

        public ProductsController(WebAppMVCContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return _context.Products != null ?
                View(await _context.Products.ToListAsync())
                : Problem("Product not found");
        }

        /// <summary>
        /// Get Create product page
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Post method for create product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        /// <summary>
        /// Get method for details
        /// /Products/Details/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null) return NotFound();
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        /// <summary>
        /// Get methods for edit page
        /// /Products/Edit/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null) return NotFound();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}

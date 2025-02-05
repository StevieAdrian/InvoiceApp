using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class MsProductController : Controller
    {
        private readonly AppDbContext _context;

        public MsProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var msproducts = await _context.MsProducts.ToListAsync();
            if (msproducts == null || !msproducts.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {msproducts.Count}");
            }

            return View(msproducts);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msproducts = await _context.MsProducts
                .FirstOrDefaultAsync(m => m.ProductID == id);

            if (msproducts == null)
            {
                return NotFound();
            }

            return View(msproducts);
        }

    }
}

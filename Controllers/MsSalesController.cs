using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class MsSalesController : Controller
    {
        private readonly AppDbContext _context;

        public MsSalesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mssales = await _context.MsSales.ToListAsync();
            if (mssales == null || !mssales.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {mssales.Count}");
            }

            return View(mssales);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mssales = await _context.MsSales
                .FirstOrDefaultAsync(m => m.SalesID == id);

            if (mssales == null)
            {
                return NotFound();
            }

            return View(mssales);
        }

    }
}

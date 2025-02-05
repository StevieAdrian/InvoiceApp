using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class TrInvoiceDetailController : Controller
    {
        private readonly AppDbContext _context;

        public TrInvoiceDetailController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var trinvoicedetail = await _context.TrInvoiceDetail.ToListAsync();
            if (trinvoicedetail == null || !trinvoicedetail.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {trinvoicedetail.Count}");
            }

            return View(trinvoicedetail);
        }

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trinvoicedetail = await _context.TrInvoiceDetail
                .FirstOrDefaultAsync(m => m.InvoiceNo == id);

            if (trinvoicedetail == null)
            {
                return NotFound();
            }

            return View(trinvoicedetail);
        }

    }
}

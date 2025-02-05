using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class MsPaymentController : Controller
    {
        private readonly AppDbContext _context;

        public MsPaymentController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mspayments = await _context.MsPayments.ToListAsync();
            if (mspayments == null || !mspayments.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {mspayments.Count}");
            }

            return View(mspayments);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mspayments = await _context.MsPayments
                .FirstOrDefaultAsync(m => m.PaymentID == id);

            if (mspayments == null)
            {
                return NotFound();
            }

            return View(mspayments);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class LtCourierFeeController : Controller
    {
        private readonly AppDbContext _context;

        public LtCourierFeeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ltcourierFees = await _context.LtCourierFees.ToListAsync();
            if (ltcourierFees == null || !ltcourierFees.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {ltcourierFees.Count}");
            }

            return View(ltcourierFees);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ltCourierFee = await _context.LtCourierFees
                .FirstOrDefaultAsync(m => m.WeightID == id);

            if (ltCourierFee == null)
            {
                return NotFound();
            }

            return View(ltCourierFee);
        }

    }
}

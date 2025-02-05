using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class MsCourierController : Controller
    {
        private readonly AppDbContext _context;

        public MsCourierController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mscouriers = await _context.MsCouriers.ToListAsync();
            if (mscouriers == null || !mscouriers.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {mscouriers.Count}");
            }

            return View(mscouriers);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var msCourier = await _context.MsCouriers
                .FirstOrDefaultAsync(m => m.CourierID == id);

            if (msCourier == null)
            {
                return NotFound();
            }

            return View(msCourier);
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvoiceApp.Data;
using InvoiceApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace InvoiceApp.Controllers
{
    public class TrInvoiceController : Controller
    {
        private readonly AppDbContext _context;


        public TrInvoiceController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var trinvoice = await _context.TrInvoice.ToListAsync();
            if (trinvoice == null || !trinvoice.Any())
            {
                Console.WriteLine("kosong");
            }
            else
            {
                Console.WriteLine($"jumlah data: {trinvoice.Count}");
            }

            return View(trinvoice);
        }

        [Route("TrInvoice/byid")]
        public async Task<IActionResult> ById(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            if (id == null)
            {
                return NotFound();
            }

            var trInvoice = await _context.TrInvoice
                .FirstOrDefaultAsync(t => t.InvoiceNo == id);
            // var trInvoice = await _context.TrInvoice
            //     .Include(t => t.TrInvoiceDetail) 
            //     .FirstOrDefaultAsync(t => t.InvoiceNo == id);

            // Console.WriteLine($"Invoice No: {trInvoice.InvoiceNo}");
            // Console.WriteLine($"Details count: {trInvoice.TrInvoiceDetail?.Count ?? 0}");

            if (trInvoice == null)
            {
                return NotFound();
            }
            
            ViewData["TrInvoice"] = trInvoice;
            ViewData["TrInvoiceDetails"] = trInvoice.TrInvoiceDetail.ToList();

            return View(trInvoice);
        }

        [HttpGet]
        [Route("TrInvoice/Edit")]
        public async Task<IActionResult> Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var trInvoice = await _context.TrInvoice
                .FirstOrDefaultAsync(t => t.InvoiceNo == id);

            if (trInvoice == null)
            {
                ViewData["Error"] = "Invoice not found.";
                return View();
            }

            ViewData["PaymentTypes"] = await _context.MsPayments.ToListAsync();
            ViewData["Sales"] = await _context.MsSales.ToListAsync();
            ViewData["Courier"] = await _context.MsCouriers.ToListAsync();

            return View(trInvoice);
        }

        [HttpPost]
        [Route("TrInvoice/Edit")]
        public async Task<IActionResult> Edit(TrInvoice trInvoice)
        {
            Console.WriteLine($"Invoice No: {trInvoice.InvoiceNo}");
            Console.WriteLine($"Invoice Date: {trInvoice.InvoiceDate}");
            Console.WriteLine($"Invoice To: {trInvoice.InvoiceTo}");
            Console.WriteLine($"Ship To: {trInvoice.ShipTo}");
            Console.WriteLine($"Payment Type: {trInvoice.PaymentType}");
            Console.WriteLine($"SalesID: {trInvoice.SalesID}");
            Console.WriteLine($"CourierID: {trInvoice.CourierID}");

            var existingInvoice = await _context.TrInvoice.FirstOrDefaultAsync(t => t.InvoiceNo == trInvoice.InvoiceNo);
            
            if (existingInvoice == null)
            {
                ViewData["Error"] = "Invoice not found.";
                return View(trInvoice);
            }
            else 
            {
                existingInvoice.InvoiceDate = trInvoice.InvoiceDate;
                existingInvoice.InvoiceTo = trInvoice.InvoiceTo;
                existingInvoice.ShipTo = trInvoice.ShipTo;
                existingInvoice.SalesID = trInvoice.SalesID;
                existingInvoice.CourierID = trInvoice.CourierID;
                existingInvoice.PaymentType = trInvoice.PaymentType;

                try
                {
                    _context.Update(existingInvoice);
                    await _context.SaveChangesAsync(); 
                    ViewData["SuccessMessage"] = "Invoice updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewData["Error"] = "Error";
                    Console.WriteLine("Eror bg");
                }

            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("TrInvoice/Delete")]
        public async Task<IActionResult> Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var trInvoice = await _context.TrInvoice
                .FirstOrDefaultAsync(t => t.InvoiceNo == id);

            if (trInvoice == null)
            {
                return NotFound();
            }

            return View(trInvoice);
        }

        [HttpPost, ActionName("Delete")]
        [Route("TrInvoice/Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trInvoice = await _context.TrInvoice
                .FirstOrDefaultAsync(t => t.InvoiceNo == id);

            if (trInvoice == null)
            {
                return NotFound();
            }

            try
            {
                _context.TrInvoice.Remove(trInvoice);
                await _context.SaveChangesAsync();
                ViewData["SuccessMessage"] = "invoice deleted!";
            }
            catch (DbUpdateConcurrencyException)
            {
                ViewData["Error"] = "error.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

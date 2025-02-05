using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    [Table("trinvoicedetail")]
    [Keyless]
    public class TrInvoiceDetail
    {
        [Required]
        [StringLength(10)]
        public string InvoiceNo { get; set; }
        [ForeignKey("InvoiceNo")]
        public virtual TrInvoice TrInvoice { get; set; }

        [Required]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual MsProduct MsProduct { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public decimal Price { get; set; } = 10.0m;

        // public TrInvoice TrInvoice { get; set; }    
    }
}
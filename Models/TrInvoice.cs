using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace InvoiceApp.Models
{
    [Table("trinvoice")]
    public class TrInvoice
    {
        [Key]
        [StringLength(10)]
        public string InvoiceNo { get; set; }

        [Required]
        public DateTime? InvoiceDate { get; set; }

        [Required]
        [StringLength(500)]
        public string InvoiceTo { get; set; }

        [Required]
        [StringLength(500)]
        public string ShipTo { get; set; }
        
        [Required]
        public int SalesID { get; set; }
        [ForeignKey("SalesID")]
        public virtual MsSales MsSales { get; set; }

        [Required]
        public int CourierID { get; set; }
        [ForeignKey("CourierID")]
        public virtual MsCourier MsCourier { get; set; }

        [Required]
        public int PaymentType { get; set; }
        [ForeignKey("PaymentType")]
        public virtual MsPayment MsPayment { get; set; }

        [Required]
        public decimal CourierFee { get; set; } = 10.0m;

        [NotMapped]
        public ICollection<TrInvoiceDetail> TrInvoiceDetail { get; set; } = new List<TrInvoiceDetail>();
    }
}
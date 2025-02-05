using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    [Table("mspayment")]
    public class MsPayment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentName { get; set; }
    }
}
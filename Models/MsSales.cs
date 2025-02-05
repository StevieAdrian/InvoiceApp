using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    [Table("mssales")]
    public class MsSales
    {
        [Key]
        public int SalesID { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesName { get; set; }
    }
}
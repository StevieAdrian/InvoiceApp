using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    [Table("mscourier")]
    public class MsCourier
    {
        [Key]
        public int CourierID { get; set; }

        [Required]
        [StringLength(50)]
        public string CourierName { get; set; }
    }
}
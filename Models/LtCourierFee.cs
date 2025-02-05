using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    [Table("ltcourierfee")]
    [Keyless]    
    public class LtCourierFee
    {
        public int WeightID { get; set; }
        public int CourierID { get; set; }
        public int StartKg { get; set; }
        public int EndKg { get; set; }
        public decimal Price { get; set; }
    }
}
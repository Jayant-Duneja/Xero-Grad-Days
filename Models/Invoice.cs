using System.ComponentModel.DataAnnotations;
namespace Xero_Grad_Days.Models
{
    public class Invoice
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string TaxRate { get; set; }
        
    }
}
using System.ComponentModel.DataAnnotations;
namespace Xero_Grad_Days.Models
{
    public class TaxCalculationRequest
    {
        [Required]
        public string CountryCode { get; set; }
        [Required]
        public List<Invoice> Invoices { get; set; }
    }
}
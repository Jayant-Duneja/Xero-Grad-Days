namespace Xero_Grad_Days.Models
{ 
    public enum AuTaxRate
    {
        Zero = 0,
        Low = 15,
        Moderate = 25,
        Standard = 35
    }
    
    public static class AuTaxRateExtensions
    {
        public static decimal GetTaxRate(this AuTaxRate taxRate)
        {
            return (decimal)taxRate / 100;
        }
    }
};

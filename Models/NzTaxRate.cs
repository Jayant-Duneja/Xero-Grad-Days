namespace Xero_Grad_Days.Models
{
    public enum NzTaxRate
    {
        Zero = 0,
        Low = 10,
        Standard = 15
    }

    public static class NzTaxRateExtensions
    {
        public static decimal GetTaxRate(this NzTaxRate taxRate)
        {
            return (decimal)taxRate / 100;
        }
    }
}
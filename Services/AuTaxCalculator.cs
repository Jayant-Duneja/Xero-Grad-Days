using Xero_Grad_Days.Models;

namespace Xero_Grad_Days.Services
{
    public class AuTaxCalculator : ITaxCalculator
    {
        public Dictionary<string, decimal> CalculateTax(List<Invoice> orders)
        {
            var result = new Dictionary<string, decimal>();

            foreach (var order in orders)
            {
                if (!result.ContainsKey(order.TaxRate))
                {
                    result[order.TaxRate] = 0;
                }
                var taxRateEnum = Enum.Parse<AuTaxRate>(order.TaxRate);
                result[order.TaxRate] += order.Amount * taxRateEnum.GetTaxRate();
            }

            return result;
        }
    }
}
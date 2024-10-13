using Xero_Grad_Days.Models;
namespace Xero_Grad_Days.Services;

public interface ITaxCalculator
{
    public Dictionary<string, decimal> CalculateTax(List<Invoice> orders);
}
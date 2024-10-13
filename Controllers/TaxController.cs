using Microsoft.AspNetCore.Mvc;
using Xero_Grad_Days.Models;
using Xero_Grad_Days.Services;

namespace Xero_Grad_Days.Controllers
{
    public class TaxController : Controller
    {
        private readonly TaxCalculatorFactory _factory;

        public TaxController(TaxCalculatorFactory factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public IActionResult CalculateTax([FromBody] TaxCalculationRequest ordersRequests)
        {
            if (ordersRequests == null || ordersRequests.Invoices == null || !ordersRequests.Invoices.Any())
            {
                return BadRequest("No orders provided.");
            }

            var country = ordersRequests.CountryCode;
            if (string.IsNullOrEmpty(country))
            {
                return BadRequest("Country code is required.");
            }
            var calculator = _factory.GetTaxCalculator(country);
            if (string.IsNullOrEmpty(country))
            {
                return BadRequest("Country code is required.");
            }
            var invoices = ordersRequests.Invoices;
            var result = calculator.CalculateTax(invoices);
            return Ok(result);
        }
    }
}
namespace Xero_Grad_Days.Services;

public class TaxCalculatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TaxCalculatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITaxCalculator GetTaxCalculator(string country)
    {
        return country switch
        {
            "NZ" => _serviceProvider.GetService<NzTaxCalculator>(),
            "AU" => _serviceProvider.GetService<AuTaxCalculator>(),
            _ => throw new NotSupportedException($"Tax calculation for country {country} is not supported.")
        };
    }
}
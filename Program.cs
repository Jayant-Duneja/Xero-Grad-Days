using Xero_Grad_Days.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<NzTaxCalculator>();
builder.Services.AddTransient<AuTaxCalculator>();
builder.Services.AddSingleton<TaxCalculatorFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.MapControllerRoute(
    name: "tax",
    pattern: "tax/calculate-tax",
    defaults: new { controller = "Tax", action = "CalculateTax" });

app.Run();
using Zip.InstallmentsService.Service;
using Zip.InstallmentsService.Service.Interface;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Host.ConfigureServices((hostContext,services) =>
{
    services.AddLogging();
    services.AddScoped<IPaymentPlanService, PaymentPlanService>();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.WebHost.UseUrls("http://*:8083");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();

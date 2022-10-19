using FluentValidation;
using FluentValidation.AspNetCore;
using Zip.InstallmentsService.Model;
using Zip.InstallmentsService.Service;
using Zip.InstallmentsService.Service.Interface;
using Zip.InstallmentsService.Validators;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Host.ConfigureServices((hostContext,services) =>
{
    services.AddLogging();
    services.AddScoped<IPaymentPlanService, PaymentPlanService>();
    services.AddScoped<IValidator<PaymentPlanInput>, PaymentPlanInputValidators>();
    services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
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

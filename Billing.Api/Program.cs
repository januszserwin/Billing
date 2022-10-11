using Billing.Application.Abstractions;
using Billing.Application.Gateways;
using Billing.Application.Guards;
using Billing.Application.Services;
using Billing.Common.Dates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IOrderForPaymentGuardRule, OrderUserIdGuard>();
builder.Services.AddScoped<IOrderForPaymentGuardRule, OrderIdGuard>();
builder.Services.AddScoped<IOrderForPaymentGuardRule, OrderAmountGuard>();
builder.Services.AddScoped<IOrderGuard, OrderGuard>();
builder.Services.AddScoped<IGatewayFactory, GatewayFactory>();
builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddScoped<StaxGateway>();
builder.Services.AddScoped<StripeGateway>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

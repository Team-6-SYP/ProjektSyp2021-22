var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add transient Controllers
builder.Services.AddTransient<QTTimeManagement.Logic.Controllers.CollectiveAgreementsController>();
builder.Services.AddTransient<QTTimeManagement.Logic.Controllers.EmployeesController>();
builder.Services.AddTransient<QTTimeManagement.Logic.Controllers.RatesController>();
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

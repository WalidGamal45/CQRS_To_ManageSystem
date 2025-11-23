using CQRS_Layer1.DBContext;
using CQRS_Layer1.Rebos;
using CQRS_Layer1.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CQRS_Layer1;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//connection string 
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Wella")));
//DI
builder.Services.AddScoped<IEmployee,EmployeeServices>();
//Mediator to CQRS
builder.Services.AddMediatR(typeof(MyLibrary).Assembly);

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

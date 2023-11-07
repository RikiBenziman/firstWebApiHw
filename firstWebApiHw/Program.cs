using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository,UserRepository >();
builder.Services.AddScoped < IUserService,UserService >();
builder.Services.AddDbContext<MySuperMarketContext>(option => option.UseSqlServer("Data Source=SRV2\\PUPILS;Initial Catalog=MySuperMarket;Integrated Security=True"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();




























































































































































































}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using NLog.Web;
using PresidentsApp.Middlewares;
using webApiShopSite.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserRepository,UserRepository >();
builder.Services.AddTransient< IUserService,UserService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();   
builder.Services.AddTransient<IRatingService, RatingService>();


builder.Services.AddDbContext<MySuperMarketContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("MySchool")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Host.UseNLog();


var app = builder.Build();

////add midellware;
app.UseErrorHandlingMiddleware();
app.UseRatingMiddleware();

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

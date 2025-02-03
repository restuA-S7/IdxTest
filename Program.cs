// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";
// var url = $"http://0.0.0.0:{port}";
// var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

// //register ef
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddControllers();

// var app = builder.Build();

// // app.MapGet("/", () => $"Hello {target}!");
// app.MapGet("api/", () => $"[controller]");

// try
// {
//     app.Run(url);
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Unhandled exception: {ex.Message}");
// }

using Microsoft.EntityFrameworkCore;
using myappAPI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//pakai swagger


//register ef
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//ini inectionnya gini aja
//DI
//builder.Services.AddScoped<ICategory, CategoriesDAL>();
//builder.Services.AddScoped<IProduct, ProducstDAL>();
//builder.Services.AddScoped<IOrderHeader, OrderHeadersDAL>();
//builder.Services.AddScoped<IOrderDetail, OrderDetailsDAL>();
//builder.Services.AddScoped<IWallet, WalletDAL>();

builder.Services.AddScoped<IUser, UsersEF>();
//builder.Services.AddScoped<IProduct, ProductsEF>();
//builder.Services.AddScoped<IOrderHeader, OrderHeadersEF>();

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
using Microsoft.EntityFrameworkCore;
using product_management.Infraestructure.Data;
using product_management.Application.Abstractions;
using product_management.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//var cs = builder.Configuration.GetConnectionString("Default") 
//    ?? "Server=STIVENR\\STIVEN;Database=Products;User Id=sa;Password=Stiven.1956*;TrustServerCertificate=True;";

var cs = builder.Configuration.GetConnectionString("prod")
    ?? "Server=tcp:products-smart-talent.database.windows.net,1433;Initial Catalog=products;Persist Security Info=False;User ID=products-smart-talent;Password=Jsr.1956;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

////// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//Habilitar Swagger SIEMPRE (en cualquier entorno)
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

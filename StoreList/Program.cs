using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreList;
using StoreList.Repository;
using StoreList.Servies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionStrings"));


builder.Services.AddSingleton<IStoreRepository, StoreRepository>();
builder.Services.AddScoped<IStoreService, StoreService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

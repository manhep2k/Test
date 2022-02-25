//using QLHDSolotion.BackendAPI;

//namespace QLHDSolotion
//{
//    public class Program
//    {
//  public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }



//    public static IHostBuilder CreateHostBuilder(string[] args) =>
//        Host.CreateDefaultBuilder(args)
//            .ConfigureWebHostDefaults(webBuilder =>
//            {
//                webBuilder.UseStartup<Startup>();
//            });

//}
//}
using Microsoft.EntityFrameworkCore;
using QLHĐSolotion.Application.Doitac;
using QLHĐSolotion.Data.EF;
using QLHĐSolotion.Data.Extensions;
using QLHĐSolotion.ViewModel.Doitac.Dtos;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<testDbontext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("eShopSolutionDb")));
//options.UseSqlServer("eShopSolutionDb");SystemConstants.MainConnectionString
builder.Services.AddTransient<IPublicDoiTacServicer, PublicDoiTacService>();

builder.Services.AddControllersWithViews();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//Declare DI

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


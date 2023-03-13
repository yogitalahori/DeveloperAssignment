using DeveloperAssignment.BAL.Contracts;
using DeveloperAssignment.BAL.Services;
using DeveloperAssignment.DAL.Contracts;
using DeveloperAssignment.DAL.Data;
using DeveloperAssignment.DAL.Repositories;
using DeveloperAssignment.Mapping;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnStr")));

builder.Services.AddScoped<IRepository<DeveloperAssignment.DAL.Models.ItemDTO>, ItemRepository>();
builder.Services.AddScoped<IItemsService, ItemService>();

builder.Services.AddAutoMapper( cfg => cfg.AddProfile<MappingProfile>(), AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

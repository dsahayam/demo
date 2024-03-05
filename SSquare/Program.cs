using HRSystems;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SSquare_HRSystem.DataRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IHRSystemsData, HRSystemsData>();
builder.Services.AddScoped<IHRSystemsProcess, HRSystemsProcess>();
//builder.Services.AddDbContext<HRSystemsContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

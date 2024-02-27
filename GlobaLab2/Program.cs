using Microsoft.EntityFrameworkCore;
using GlobaLab2.Models;

var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GlobaLab2Context>(options => options.UseSqlServer(connection));

builder.Services.AddMvc();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}"
);

app.Run();
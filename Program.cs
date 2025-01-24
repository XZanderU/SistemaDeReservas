using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaReservas.Data;
using SistemaReservas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    // Usar SQLite para el entorno de desarrollo
    builder.Services.AddDbContext<SistemaReservasContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SistemaReservasContext"))
    );
}
else
{
    // Usar SQL Server para el entorno de producción
    builder.Services.AddDbContext<SistemaReservasContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionReservasContext"))
    );
}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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

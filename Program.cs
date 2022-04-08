using Teatru.Data;

using Microsoft.EntityFrameworkCore;
using Teatru.Services.ClientServices;
using Microsoft.AspNetCore.Builder;
using Teatru.Services.RezervareServices;
using Teatru.Services.ScenetaServices;
using Teatru.Services.LocServices;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IRezervareService, RezervareService>();
builder.Services.AddScoped<IScenetaService, ScenetaService>();
builder.Services.AddScoped<ILocService, LocService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<TeatruContext>(options =>
{
    options.UseSqlServer(@"Data Source=DESKTOP-B4L629N;Initial Catalog=Teatru;Integrated Security=True");
});


builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Index}/{id?}");

app.Run();

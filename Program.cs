using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Areas.Identity.Data;
using ProjetoMVC.Data;
using DespesasControlApp.Infra.Database;
using DespesasControlApp.Services;
using WebCRUDMVCSQL.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ProjetoMVCContextConnection") ?? throw new InvalidOperationException("Connection string 'ProjetoMVCContextConnection' not found.");

builder.Services.AddDbContext<ProjetoMVCContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<UsuarioModel>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ProjetoMVCContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DespesasControlContext>();

builder.Services.AddScoped<IDespesasService, DespesasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "Index",
    pattern: "Dashboard",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "BancoImagens",
    pattern: "banco-de-imagens",
    defaults: new { controller = "Home", action = "BancoImagens" });

app.MapControllerRoute(
    name: "Republica",
    pattern: "123",
    defaults: new { controller = "home", action = "Republica" });

app.MapControllerRoute(
    name: "Despesas",
    pattern: "Despesas",
    defaults: new { controller = "Expensive", action = "Despesas" });

app.MapControllerRoute(
    name: "Pessoas",
    pattern: "Pessoas",
    defaults: new { controller = "Home", action = "Pessoas" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();

app.Run();
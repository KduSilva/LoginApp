using LoginApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=LoginApp.db"));

// Ativar sessões
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Razor Pages
builder.Services.AddRazorPages();

var app = builder.Build();

// Middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

// Roteamento Razor Pages
app.MapRazorPages();

// (Opcional) Se quiser que "/" leve direto ao Login:
app.MapFallbackToPage("/Login");

app.Run();
using Microsoft.EntityFrameworkCore;
using LoginApp.Models;


namespace LoginApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } // Tabela de usuarios 

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db"); // Caminho do banco SQLite


    }
}
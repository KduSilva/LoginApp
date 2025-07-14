
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginApp.Data;
using LoginApp.Models;
using System.Linq;

namespace LoginApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string UsuarioNome { get; set; }

        [BindProperty]
        public string UsuarioSenha { get; set; }

        public string Mensagem { get; set; }

        public void OnPost()
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UsuarioNome == UsuarioNome && u.UsuarioSenha == UsuarioSenha);

            if (user != null)
                Mensagem = "Login realizado com sucesso!";
            else
                Mensagem = "Usuário ou senha inválidos.";
        }
    }
}
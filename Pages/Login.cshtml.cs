using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginApp.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LoginApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "Digite o usuário ou e-mail.")]
        public string Identificador { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Digite a senha.")]
        public string UsuarioSenha { get; set; }

        public string Mensagem { get; set; }

        public void OnPost()
        {
            var user = _context.Users
                .FirstOrDefault(u =>
                    (u.UsuarioNome == Identificador || u.Email == Identificador) &&
                    u.UsuarioSenha == UsuarioSenha);

            if (user != null)
            {
                // Grava o nome do usuário na sessão
                HttpContext.Session.SetString("UsuarioLogado", user.UsuarioNome);

                Response.Redirect("/Dashboard");
            }
            else
            {
                Mensagem = "Usuário/E-mail ou senha inválidos.";
            }
        }
    }
}
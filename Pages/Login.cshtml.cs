using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginApp.Models;
using LoginApp.Data;
using LoginApp.Helpers; // Importa a classe de hash
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
        [Required(ErrorMessage = "Informe o e-mail ou nome de usuário.")]
        public string Identificador { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }

        public string MensagemErro { get; set; }

        public void OnPost()
        {
            // Gera o hash da senha digitada
            string senhaHash = HashHelper.ComputeSha256Hash(Senha);

            // Busca o usuário pelo identificador (e-mail ou nome) e compara hash
            var usuario = _context.Users.FirstOrDefault(u =>
                (u.Email == Identificador || u.UsuarioNome == Identificador) &&
                u.UsuarioSenha == senhaHash);

            if (usuario != null)
            {
                // Armazena dados de sessão, por exemplo
                HttpContext.Session.SetString("usuario_nome", usuario.UsuarioNome);

                // Redireciona para a dashboard ou página protegida
                Response.Redirect("/Dashboard");
            }
            else
            {
                MensagemErro = "Usuário ou senha inválidos.";
            }
        }
    }
}
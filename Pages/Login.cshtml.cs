using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginApp.Data;
using LoginApp.Helpers;
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
        public string Identificador { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; } = string.Empty;

        public string MensagemErro { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            // Se já está logado, redireciona
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("usuario_nome")))
                return RedirectToPage("/Dashboard");

            return Page();
        }

        public IActionResult OnPost()
        {
            string senhaHash = HashHelper.ComputeSha256Hash(Senha);

            var usuario = _context.Users.FirstOrDefault(u =>
                (u.Email == Identificador || u.UsuarioNome == Identificador) &&
                u.UsuarioSenha == senhaHash);

            if (usuario != null)
            {
                HttpContext.Session.SetString("usuario_nome", usuario.UsuarioNome);
                return RedirectToPage("/Dashboard");
            }

            MensagemErro = "Usuário ou senha inválidos.";
            return Page();
        }
    }
}
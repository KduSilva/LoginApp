using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginApp.Models;
using LoginApp.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LoginApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _context;

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string UsuarioNome { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string UsuarioSenha { get; set; }

        public string Mensagem { get; set; }

        public void OnPost()
        {
            // Verifica se já existe usuário com mesmo nome ou e-mail
            var existente = _context.Users
                .FirstOrDefault(u => u.UsuarioNome == UsuarioNome || u.Email == Email);

            if (existente != null)
            {
                Mensagem = "Nome de usuário ou e-mail já cadastrados.";
                return;
            }

            // Cria novo usuário
            var novo = new User
            {
                UsuarioNome = UsuarioNome,
                Email = Email,
                UsuarioSenha = UsuarioSenha
            };

            _context.Users.Add(novo);
            _context.SaveChanges();

            // Redireciona para página de confirmação
            Response.Redirect("/Confirmacao");
        }
    }
}
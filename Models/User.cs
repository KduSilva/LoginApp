using System.ComponentModel.DataAnnotations;

namespace LoginApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UsuarioNome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string UsuarioSenha { get; set; } = string.Empty;
    }
}
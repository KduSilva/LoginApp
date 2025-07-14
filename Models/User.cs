using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioSenha { get; set; }
    }
}
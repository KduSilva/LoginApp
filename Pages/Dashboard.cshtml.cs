using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class DashboardModel : PageModel
    {
        public string UsuarioNome { get; set; } = string.Empty;

        public IActionResult OnGet()
        {
            var nome = HttpContext.Session.GetString("usuario_nome");

            if (string.IsNullOrEmpty(nome))
                return RedirectToPage("/Login");

            UsuarioNome = nome;
            return Page();
        }
    }
}
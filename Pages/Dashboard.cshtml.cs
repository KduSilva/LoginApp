using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class DashboardModel : PageModel
    {
        public string UsuarioNome { get; set; }

        public void OnGet()
        {
            UsuarioNome = HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(UsuarioNome))
            {
                // Se não estiver logado, redireciona pro login
                Response.Redirect("/Login");
            }
        }

        public void OnPost()
        {
            HttpContext.Session.Remove("UsuarioLogado");
            Response.Redirect("/Login");
        }
    }
}
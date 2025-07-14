using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginApp.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("usuario_nome");
            TempData["Despedida"] = "Você saiu do sistema com sucesso. 👋";
            return RedirectToPage("/Login");
        }
    }
}
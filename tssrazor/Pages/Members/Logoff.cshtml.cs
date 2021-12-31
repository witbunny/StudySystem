using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tssrazor.Pages.Members
{
    public class LogoffModel : PageModel
    {
        public IActionResult OnGet()
        {
            Response.Cookies.Delete(Keys.UserId);
            //return RedirectToPage("/Members/Logon");
            return Redirect(Request.Headers["Referer"][0]);
        }
    }
}

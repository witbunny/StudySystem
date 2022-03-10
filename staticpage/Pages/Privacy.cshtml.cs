using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace staticpage.Pages
{
    [IgnoreAntiforgeryToken]
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //return new JsonResult(new { name = "leo", age = 23 });
        }

        public IActionResult OnPost()
		{
            //throw new Exception("hahhah");
            return new JsonResult(new { name = "leo", age = 23 });
        }
    }
}

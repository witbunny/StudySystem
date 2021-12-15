using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace staticpage.Pages
{
    //[IgnoreAntiforgeryToken]
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //[BindProperty]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public User NewUser { get; set; }

        public bool RememberMe { get; set; }

        public IEnumerable<SelectListItem> AvailableMonths { get; set; }
        public int BirthMonth { get; set; }
        public IEnumerable<int> Months { get; set; }

        public IList<hobby> Hobbies { get; set; }

        public string tennis { get; set; } = "tennis";

        public void OnGet()
        {
            UserName = "leo";
            Password = "123456";

            NewUser = new User()
            {
                UserName = "tik",
                Password = "456",
                IsMale = true
            };

            //AvailableMonths = new List<SelectListItem>
            //{
            //    new SelectListItem("一月", "1"),
            //    new SelectListItem("二月", "2"),
            //    new SelectListItem("三月", "3", true),
            //    new SelectListItem("四月", "4"),
            //    new SelectListItem("五月", "5")
            //};
            AvailableMonths = new SelectList(new int[] { 1, 2, 3, 4, 5 }, 3);

            Hobbies = new List<hobby>
            {
                new hobby() { Id = 1, Content = "网球" },
                new hobby() { Id = 2, Content = "篮球" },
                new hobby() { Id = 3, Content = "足球" }
            };
        }

        public void OnPost() 
        {
            var mon = Request.Form["Months"][0];
        }
    }

    public class User
	{
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsMale { get; set; }
    }

    public class hobby
	{
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsLike { get; set; } 
	}
}

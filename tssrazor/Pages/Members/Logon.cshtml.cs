using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities;
using tssrazor.Repositories;

namespace tssrazor.Pages.Members
{
    public class LogonModel : PageModel
    {
        private UserRepository userRepository;

        public LogonModel()
        {
            userRepository = new UserRepository();
        }

        [BindProperty]
        public User LogonUser { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "* 验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 长度为4个")]
        public string CaptchaCode { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public void OnGet()
        {
            RememberMe = true;

            ViewData["HasLogon"] = Request.Cookies[Keys.UserId];


			var temp = TempData[Keys.ErrorInPost];
			//var temp = TempData.Peek(Keys.ErrorInPost);
			if (temp != null)
			{
                //Dictionary<string, string> errors = TempData[Keys.ErrorInPost] as Dictionary<string, string>;
                Dictionary<string, string> errors = temp as Dictionary<string, string>;

                foreach (var item in errors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }
            //ModelState.Merge((ModelStateDictionary)TempData["errorInPost"]);
        }

        public RedirectToPageResult OnPost()
		{
            User ExistUser = userRepository.Find(LogonUser.Name);

			if (ExistUser == null)
			{
                ModelState.AddModelError("LogonUser.Name", "用户名不存在");
			}
			else if (ExistUser.Password != LogonUser.Password)
			{
                ModelState.AddModelError("LogonUser.Password", "用户名或密码错误");
			}
            //else nothing

            if (!ModelState.IsValid)
            {
                Dictionary<string, string> errors =
                    ModelState.Where(m => m.Value.Errors.Any()).ToDictionary(
                        m => m.Key, 
                        m => m.Value.Errors.Select(e => e.ErrorMessage).First());

                TempData[Keys.ErrorInPost] = errors;
                return RedirectToPage();
            }

            CookieOptions cookieOptions = new CookieOptions();
			if (RememberMe)
			{
                cookieOptions.Expires = DateTime.Now.AddDays(30);
			}
            //else nothing

            Response.Cookies.Append(Keys.UserId, ExistUser.Id.ToString(), cookieOptions);
            return RedirectToPage("/Index");
        }
    }
}

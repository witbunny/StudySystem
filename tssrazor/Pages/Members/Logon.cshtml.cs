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
using tssrazor.Filters;
using tssrazor.Repositories;

namespace tssrazor.Pages.Members
{
    [ModelValidation]
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

        public IActionResult OnGet()
        {
			string url = Convert.ToString(RouteData.Values["refererURL"]);
            if (string.IsNullOrEmpty(url))
			{
                return RedirectToPage(new { refererURL = Request.Headers["Referer"][0] });
			}

            RememberMe = true;

            //ViewData["HasLogon"] = Request.Cookies[Keys.UserId];

            
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

            string captcha = "SQDU";
            //生成图片
            //Response.Cookies.Append(Keys.Captcha, captcha);
            HttpContext.Session.SetString(Keys.Captcha, captcha);

            return Page();
        }

        public IActionResult OnPost()
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

            //string captcha = Request.Cookies[Keys.Captcha];
            string captcha = HttpContext.Session.GetString(Keys.Captcha);
			if (captcha != CaptchaCode?.ToUpper())
			{
                ModelState.AddModelError("CaptchaCode", "验证码错误");
                //Response.Cookies.Delete(Keys.Captcha);
			}

			if (!ModelState.IsValid)
			{
				Dictionary<string, string> errors =
					ModelState.Where(m => m.Value.Errors.Any()).ToDictionary(
						m => m.Key,
						m => m.Value.Errors.Select(e => e.ErrorMessage).First());

				TempData[Keys.ErrorInPost] = errors;
                //return RedirectToPage();
                return Redirect(Request.Path.Value);
			}

			CookieOptions cookieOptions = new CookieOptions();
			if (RememberMe)
			{
                cookieOptions.Expires = DateTime.Now.AddDays(30);
			}
            //else nothing

            Response.Cookies.Append(Keys.UserId, ExistUser.Id.ToString(), cookieOptions);

            string url = Convert.ToString(RouteData.Values["refererURL"]);

			//var url1 = Uri.EscapeUriString(url);
			//var url2 = Uri.EscapeDataString(url);

			url = Uri.UnescapeDataString(url);
			return Redirect(url);
        }
    }
}

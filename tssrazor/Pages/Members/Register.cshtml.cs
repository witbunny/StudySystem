using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tssrazor.Entities;
using tssrazor.Repositories;
using tssrazor.Validations;

namespace tssrazor.Pages.Members
{
    //[IgnoreAntiforgeryToken]
    //[BindProperties]
    public class RegisterModel : PageModel
    {
        private UserRepository userRepository;

		public RegisterModel()
		{
            userRepository = new UserRepository();
		}

        [BindProperty]
        public Register Register { get; set; }
        
        public User NewUser { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
		{
			if (Request.Form["ajax"].Count != 0 && Request.Form["ajax"][0] == "invite")
			{
                IList<User> invitedList = userRepository.FindList(Register.InvitedName);
                return new JsonResult(invitedList);
			}

            if (Request.Form["ajax"].Count != 0 && Request.Form["ajax"][0] == "name")
            {
                User existUser = userRepository.Find(Register.Name);
                return new JsonResult(existUser);
            }

            User invitedUser = userRepository.Find(Register.InvitedName);

            if (invitedUser == null)
			{
                ModelState.AddModelError("Register.InvitedName", "* 邀请人不存在");
            }
			else if (invitedUser.InviteCode != Register.InvitedCode)
			{
                ModelState.AddModelError("Register.InvitedCode", "* 邀请码不一致");
            }
            //else nothing 

            User ExistUser = userRepository.Find(Register.Name);

			if (ExistUser != null)
			{
                ModelState.AddModelError("Register.Name", "* 用户名已注册");
            }

			if (!ModelState.IsValid)
			{
                return Page();
			}

            NewUser = new User(userRepository, Register.Name)
            {
                Password = Register.Password,
                InvitedBy = invitedUser
            };

            userRepository.Save(NewUser);

            return Page();
		}
    }

    public class Register
	{
        [Required(ErrorMessage = "* 邀请人不能为空")]
        public string InvitedName { get; set; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 长度为4个")]
        public string InvitedCode { get; set; }


        [Required(ErrorMessage = "* 用户名不能为空")]
        [NamePassword]
        [Display(Name = "用户名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* 密码不能为空")]
        [MinLength(4, ErrorMessage = "* 长度不小于4个")]
        [NamePassword]
        [Display(Name = "密码")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "* 确认密码不能为空")]
        [Compare("Password", ErrorMessage = "* 必须和密码相同")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "* 验证码不能为空")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* 长度为4个")]
        public string CaptchaCode { get; set; }
    }
}

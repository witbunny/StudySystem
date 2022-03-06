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
                ModelState.AddModelError("Register.InvitedName", "* �����˲�����");
            }
			else if (invitedUser.InviteCode != Register.InvitedCode)
			{
                ModelState.AddModelError("Register.InvitedCode", "* �����벻һ��");
            }
            //else nothing 

            User ExistUser = userRepository.Find(Register.Name);

			if (ExistUser != null)
			{
                ModelState.AddModelError("Register.Name", "* �û�����ע��");
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
        [Required(ErrorMessage = "* �����˲���Ϊ��")]
        public string InvitedName { get; set; }

        [Required(ErrorMessage = "* �����벻��Ϊ��")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* ����Ϊ4��")]
        public string InvitedCode { get; set; }


        [Required(ErrorMessage = "* �û�������Ϊ��")]
        [NamePassword]
        [Display(Name = "�û���")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* ���벻��Ϊ��")]
        [MinLength(4, ErrorMessage = "* ���Ȳ�С��4��")]
        [NamePassword]
        [Display(Name = "����")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "* ȷ�����벻��Ϊ��")]
        [Compare("Password", ErrorMessage = "* �����������ͬ")]
        //[DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "* ��֤�벻��Ϊ��")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "* ����Ϊ4��")]
        public string CaptchaCode { get; set; }
    }
}

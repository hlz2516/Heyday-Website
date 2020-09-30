using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class ChangePasswordDto
    {
        [Display(Name = "邮箱地址")]
        [Required(ErrorMessage = "请填写邮箱地址")]
        [EmailAddress(ErrorMessage = "格式不正确，请正确填写邮箱地址")]
        public string Email { get; set; }
        [Display(Name ="新密码")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]\w{5,17}$", ErrorMessage = "正确格式：以字母开头，长度在6-18之间，只能包含字符，数字和下划线")]
        public string Password { get; set; }
        [Display(Name ="确认密码")]
        [Compare("Password",ErrorMessage ="密码不一致！")]
        public string PasswordVerify { get; set; }

    }
}

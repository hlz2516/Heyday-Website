using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class RegisterDto
    {
        [Display(Name ="邮箱地址")]
        [Required(ErrorMessage ="请填写邮箱地址")]
        [EmailAddress(ErrorMessage ="格式不正确，请正确填写邮箱地址")]
        [Remote("IsSameEmail","Account",ErrorMessage ="此邮箱已被注册")]
        public string Email { get; set; }
        [Display(Name ="昵称")]
        [Required(ErrorMessage ="请填写昵称")]
        [StringLength(16,MinimumLength =4,ErrorMessage ="昵称长度在4~16个字符之间")]
        public string Name { get; set; }
        [Display(Name ="密码")]
        [Required(ErrorMessage ="请填写密码")]
        [RegularExpression(@"^[a-zA-Z]\w{5,17}$",ErrorMessage ="正确格式：以字母开头，长度在6-18之间，只能包含字符，数字和下划线")]
        public string Password { get; set; }
        [Required(ErrorMessage ="请填写验证码")]
        public string Code { get; set; }

    }
}

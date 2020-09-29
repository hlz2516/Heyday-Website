using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class LoginDto
    {
        [Display(Name ="邮箱地址")]
        [EmailAddress(ErrorMessage ="邮箱格式不正确")]
        public string Email { get; set; }
        [Display(Name ="密码")]
        [RegularExpression(@"^[a-zA-Z]\w{5,17}$", ErrorMessage = "正确格式：以字母开头，长度在6-18之间，只能包含字符，数字和下划线")]
        public string Password { get; set; }
        public bool Remember { get; set; }

    }
}

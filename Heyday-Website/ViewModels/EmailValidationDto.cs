using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Heyday_Website.ViewModels
{
    public class EmailValidationDto
    {
        [Display(Name ="邮箱地址")]
        [Required(ErrorMessage ="请填写邮箱")]
        [EmailAddress(ErrorMessage ="邮箱格式不正确")]
        [Remote("IsSameEmail", "Account",ErrorMessage ="此邮箱不存在")]
        public string Email { get; set; }
        public string Code { get; set; }
    }
}

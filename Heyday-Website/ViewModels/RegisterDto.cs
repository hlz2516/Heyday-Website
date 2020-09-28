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
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name ="昵称")]
        [Required]
        [MinLength(4)]
        public string Name { get; set; }
        [Display(Name ="密码")]
        [Required]
        [StringLength(16,MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        public string Code { get; set; }

    }
}
